using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    internal enum driver
    {
        AI,
        keyboards,
        mobile
    }
    [SerializeField] driver driverController;

    [SerializeField] public float vertical;
    [SerializeField] public float horizontal;
    [SerializeField] public bool handbrake;
    [SerializeField] public bool boosting;

    public trackWaypoints waypoints;
    public Transform currentWaypotint;
    public List<Transform> nodes = new List<Transform>();
    [Range(0, 10)] public int distanceOffset;
    [Range(0, 5)] public float steerForce;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectWithTag("path").GetComponent<trackWaypoints>();

        nodes = waypoints.nodes;
    }

    private void FixedUpdate()
    {
        switch (driverController)
        {
            case driver.AI:
                AIDrvie();
                break;
            case driver.keyboards:
                keyboardDrive();
                break;
            case driver.mobile:
                break;
        }
        calculateDistanceOfWaypoints();
    }

    private void AIDrvie()
    {
        vertical = .3f;
        AISteer();
    }

    private void keyboardDrive()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0) ? true : false;
        if (Input.GetKey(KeyCode.LeftShift)) boosting = true; else boosting = false;
    }

    private void mobileDrive()
    {

    }

    private void calculateDistanceOfWaypoints()
    {
        Vector3 position = gameObject.transform.position;
        float distance = Mathf.Infinity;

        for(int i = 0; i < nodes.Count; i++)
        {
            Vector3 difference = nodes[i].transform.position - position;
            float currentDistance = difference.magnitude;
            if(currentDistance < distance)
            {
                currentWaypotint = nodes[i + distanceOffset];
                distance = currentDistance;
            }
        }
    }

    private void AISteer()
    {
        Vector3 relative = transform.InverseTransformPoint(currentWaypotint.transform.position);
        relative /= relative.magnitude;

        horizontal = (relative.x / relative.magnitude) * steerForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentWaypotint.position,3);
    }
}
