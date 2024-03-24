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
    [SerializeField] private float DownForceValue = 50;
    [SerializeField] private int moterTorque = 100;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float steeringMax = 20;
    [SerializeField] private float thrust = 1000f;
    private inputManager IM;
    private GameObject wheelMeshes, wheelColliders;
    private WheelCollider[] wheels = new WheelCollider[4];
    private GameObject[] wheelMesh = new GameObject[4];
    public GameObject centerOfMass;
    private Rigidbody rigidbody;

    [Header("DEBUG")]
    public float[] slip = new float[4];

    void Start()
    {
        getObjects();
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

        // 핸드브레이크 적용 여부에 따른 브레이크 토크 설정
        if (IM.handbrake)
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = breakPower;
        }
        else
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = 0;
        }

        // 부스팅 중일 때 전진 힘 추가
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

    private void getObjects()
    {
        IM = GetComponent<inputManager>();
        rigidbody = GetComponent<Rigidbody>();
        wheelColliders = GameObject.Find("colliders");
        wheelMeshes = GameObject.Find("meshes");
        wheels[0] = wheelColliders.transform.Find("0").gameObject.GetComponent<WheelCollider>();
        wheels[1] = wheelColliders.transform.Find("1").gameObject.GetComponent<WheelCollider>();
        wheels[2] = wheelColliders.transform.Find("2").gameObject.GetComponent<WheelCollider>();
        wheels[3] = wheelColliders.transform.Find("3").gameObject.GetComponent<WheelCollider>();

        wheelMesh[0] = wheelMeshes.transform.Find("0").gameObject;
        wheelMesh[1] = wheelMeshes.transform.Find("1").gameObject;
        wheelMesh[2] = wheelMeshes.transform.Find("2").gameObject;
        wheelMesh[3] = wheelMeshes.transform.Find("3").gameObject;




        centerOfMass = GameObject.Find("mass");
        rigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }
    private void addDownForce()
    {
        rigidbody.AddForce(-transform.up * DownForceValue * rigidbody.velocity.magnitude);
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
}
