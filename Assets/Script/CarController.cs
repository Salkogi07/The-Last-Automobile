using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDriv,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] private driveType drive;

    [Header("Variables")]
    public float KPH;
    private float radius = 6;
    [SerializeField] private float breakPower;
    [SerializeField] private float downForceValue;
    [SerializeField] private int moterTorque;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float steeringMax;
    [SerializeField] public float thrust;
    private float originalMaxSpeed;

    private inputManager IM;
    private CameraCotroller camera;
    public GameObject wheelMeshes, wheelColliders;
    private WheelCollider[] wheels = new WheelCollider[4];
    private GameObject[] wheelMesh = new GameObject[4];
    public GameObject centerOfMass;
    public ParticleSystem[] dustTrial;
    private Rigidbody rigidbody;
    private bool isBoosting = false;
    public float effectDuration = 5f; // 아이템 효과가 지속되는 시간
    public float speedMultiplier = 1f;
    private float currenteffectDuration = 5f; // 아이템 효과가 지속되는 시간

    [Header("DEBUG")]
    public float[] slip = new float[4];

    // 엔진 소리 관련 변수
    public AudioSource engineSound;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    public float minVolume = 0.2f;
    public float maxVolume = 0.5f;

    void Start()
    {
        getObjects();
        getFigure();
        originalMaxSpeed = maxSpeed;

        // 엔진 소리 설정
        engineSound.loop = true;
        // 예를 들어, 엔진 소리 파일 설정
        // engineSound.clip = yourEngineSoundClip;
        engineSound.Play();
    }

    private void getObjects()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraCotroller>();
        IM = GetComponent<inputManager>();
        rigidbody = GetComponent<Rigidbody>();
        wheels[0] = wheelColliders.transform.Find("0").gameObject.GetComponent<WheelCollider>();
        wheels[1] = wheelColliders.transform.Find("1").gameObject.GetComponent<WheelCollider>();
        wheels[2] = wheelColliders.transform.Find("2").gameObject.GetComponent<WheelCollider>();
        wheels[3] = wheelColliders.transform.Find("3").gameObject.GetComponent<WheelCollider>();

        wheelMesh[0] = wheelMeshes.transform.Find("0").gameObject;
        wheelMesh[1] = wheelMeshes.transform.Find("1").gameObject;
        wheelMesh[2] = wheelMeshes.transform.Find("2").gameObject;
        wheelMesh[3] = wheelMeshes.transform.Find("3").gameObject;

        rigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }

    private void getFigure()
    {
        if (gameObject.tag == "Player")
        {
            breakPower = GameManager.instance.breakPower;
            downForceValue = GameManager.instance.downForceValue;
            moterTorque = GameManager.instance.moterTorque;
            maxSpeed = GameManager.instance.maxSpeed;
            steeringMax = GameManager.instance.steeringMax;
        }
    }

    private void FixedUpdate()
    {
        addDownForce();
        animetWheels();
        moveVchicle();
        steerVchicle();
        getFriction();

        // 엔진 소리 조절
        AdjustEngineSound();
    }


    private void moveVchicle()
    {
        // 현재 속도를 km/h로 변환
        KPH = rigidbody.velocity.magnitude * 3.6f;

        // 제한 속도 설정
        if (KPH > maxSpeed)
        {
            // 제한 속도를 초과할 경우 현재 속도를 제한 속도로 조정
            rigidbody.velocity = (maxSpeed / 3.6f) * rigidbody.velocity.normalized;
        }

        // 차량 이동 로직
        if (drive == driveType.allWheelDrive)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (moterTorque / 4) * speedMultiplier;
            }
        }
        else if (drive == driveType.rearWheelDrive)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (moterTorque / 2) * speedMultiplier;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].motorTorque = IM.vertical * (moterTorque / 2);
            }
        }

        if (IM.handbrake)
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = breakPower;

            // 브레이크 파티클 활성화
            foreach (ParticleSystem ps in dustTrial)
            {
                if (!ps.isPlaying)
                    ps.Play();
            }
        }
        else
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = 0;

            // 브레이크 파티클 비활성화
            foreach (ParticleSystem ps in dustTrial)
            {
                if (ps.isPlaying)
                    ps.Stop();
            }
        }
    }

    private void steerVchicle()
    {
        if (IM.horizontal > 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
        }
        else if (IM.horizontal < 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
        }
        else
        {
            wheels[0].steerAngle = 0;
            wheels[1].steerAngle = 0;
        }
    }

    private void animetWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            //wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }


    private void addDownForce()
    {
        rigidbody.AddForce(-transform.up * downForceValue * rigidbody.velocity.magnitude);
    }

    private void getFriction()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.sidewaysSlip;
        }
    }

    public void ApplySlowdown(float factor)
    {
        maxSpeed *= factor; // 속도 감속
    }

    public void RemoveSlowdown()
    {
        maxSpeed = originalMaxSpeed; // 속도를 원래대로 복구
    }

    public void StartBoost()
    {
        if (!isBoosting)
        {
            isBoosting = true;
            camera.isboost = true;
            StartCoroutine(BoostTimer());
        }
    }

    IEnumerator BoostTimer()
    {
        // 아이템 효과 활성화
        while (currenteffectDuration > 0)
        {
            //rigidbody.AddForce(Vector3.forward * thrust);
            //speedMultiplier = 10f;
            currenteffectDuration -= Time.deltaTime;
            yield return null;
        }
        // 아이템 효과 비활성화
        isBoosting = false;
        camera.isboost = false;
        speedMultiplier = 1f;
        currenteffectDuration = effectDuration;
    }

    // 엔진 소리 조절
    private void AdjustEngineSound()
    {
        // 현재 속도를 기반으로 엔진 소리의 pitch와 volume을 조절
        float pitch = Mathf.Lerp(minPitch, maxPitch, KPH / maxSpeed);
        float volume = Mathf.Lerp(minVolume, maxVolume, KPH / maxSpeed);

        // pitch와 volume 설정
        engineSound.pitch = pitch;
        engineSound.volume = volume;
    }
}
