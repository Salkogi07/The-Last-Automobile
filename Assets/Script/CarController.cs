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
    [SerializeField] private float thrust;
    private float originalMaxSpeed;

    private inputManager IM;
    public GameObject wheelMeshes, wheelColliders;
    private WheelCollider[] wheels = new WheelCollider[4];
    private GameObject[] wheelMesh = new GameObject[4];
    public GameObject centerOfMass;
    public ParticleSystem[] dustTrial;
    private Rigidbody rigidbody;

    [Header("DEBUG")]
    public float[] slip = new float[4];

    void Start()
    {
        getObjects();
        getFigure();
        originalMaxSpeed = maxSpeed;
    }

    private void getObjects()
    {
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
        if(gameObject.tag == "Player")
        {
            breakPower = GameManager.instance.breakPower;
            downForceValue = GameManager.instance.downForceValue;
            moterTorque = GameManager.instance.moterTorque;
            maxSpeed = GameManager.instance.maxSpeed;
            steeringMax = GameManager.instance.steeringMax;
            thrust = GameManager.instance.thrust1;
            thrust = GameManager.instance.thrust2;
        }
    }
    private void FixedUpdate()
    {
        addDownForce();
        animetWheels();
        moveVchicle();
        steerVchicle();
        getFriction();
    }


    private void moveVchicle()
    {

        // ���� �ӵ��� km/h�� ��ȯ
        KPH = rigidbody.velocity.magnitude * 3.6f;

        // ���� �ӵ� ����
        if (KPH > maxSpeed)
        {
            // ���� �ӵ��� �ʰ��� ��� ���� �ӵ��� ���� �ӵ��� ����
            rigidbody.velocity = (maxSpeed / 3.6f) * rigidbody.velocity.normalized;
        }

        // ���� �̵� ����
        if (drive == driveType.allWheelDrive)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (moterTorque / 4);
            }
        }
        else if (drive == driveType.rearWheelDrive)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (moterTorque / 2);
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

            // �극��ũ ��ƼŬ Ȱ��ȭ
            foreach (ParticleSystem ps in dustTrial)
            {
                if (!ps.isPlaying)
                    ps.Play();
            }
        }
        else
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = 0;

            // �극��ũ ��ƼŬ ��Ȱ��ȭ
            foreach (ParticleSystem ps in dustTrial)
            {
                if (ps.isPlaying)
                    ps.Stop();
            }
        }

        if (IM.boosting)
        {
            rigidbody.AddForce(Vector3.forward * thrust);
        }
    }

    private void steerVchicle()
    {
        if(IM.horizontal > 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
        }
        else if(IM.horizontal < 0)
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
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }


    private void addDownForce()
    {
        rigidbody.AddForce(-transform.up * downForceValue * rigidbody.velocity.magnitude);
    }

    private void getFriction()
    {
        for(int i = 0; i < wheels.Length; i++)
        {
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.sidewaysSlip;
        }
    }

    public void ApplySlowdown(float factor)
    {
        maxSpeed *= factor; // �ӵ� ����
    }

    public void RemoveSlowdown()
    {
        maxSpeed = originalMaxSpeed; // �ӵ��� ������� ����
    }
}
