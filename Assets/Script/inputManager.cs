using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    private GameManager gameManager;

    internal enum driver
    {
        AI,
        keyboards,
    }
    [SerializeField] driver driverController;

    [SerializeField] public float vertical;
    [SerializeField] public float horizontal;
    [SerializeField] public bool handbrake;
    [SerializeField] public bool boosting;

    public trackWaypoints waypoints;
    public Transform currentWaypotint;
    public List<Transform> nodes = new List<Transform>();
    private int distanceOffset = 3;
    private float sterrForce = 1f;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectWithTag("path").GetComponent<trackWaypoints>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        nodes = waypoints.nodes;
    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "AI") AIDrvie();
        else if(gameObject.tag == "Player")
        {
            calculateDistanceOfWaypoints();
            keyboardDrive();
        }
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
                if((i + distanceOffset) >= nodes.Count)
                {
                    currentWaypotint = nodes[1];
                    distance = currentDistance;
                }
                else
                {
                    currentWaypotint = nodes[i + distanceOffset];
                    distance = currentDistance;
                }
            }
        }
    }

    private void AISteer()
    {
        Vector3 relative = transform.InverseTransformPoint(currentWaypotint.transform.position);
        relative /= relative.magnitude;

        horizontal = (relative.x / relative.magnitude) * sterrForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentWaypotint.position,3);
    }
}
