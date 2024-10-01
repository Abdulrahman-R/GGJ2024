using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovements : MonoBehaviour
{
    [Header("movment settings :")]
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int currentWaypoint;

    [Header("moving platform with frequent stops settings:")]
    [SerializeField] float delayTime;
    [SerializeField] bool onStop;

    public enum MovementMode
    {
        FrequentStops,
        ContinuousMovement
    }

    [SerializeField] MovementMode currentMode;

    // Start is called before the first frame update
    private void Start()
    {
        onStop = false;

        if (waypoints.Count <= 0) return;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (waypoints.Count <= 0) return;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) <= 0)
        {
            switch (currentMode)
            {
                case MovementMode.FrequentStops:
                    UpdateDestinationWithDelay();
                    break;
                case MovementMode.ContinuousMovement:
                    UpdateDestination();
                    break;

            }
        }
    }

    private void UpdateDestination()
    {
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Count)
        {
            waypoints.Reverse();
            currentWaypoint = 0;
        }
    }

    private void UpdateDestinationWithDelay()
    {
        StartCoroutine(StopPlatform());
    }


    IEnumerator StopPlatform()
    {
        if (onStop == false)
        {
            onStop = true;

            yield return new WaitForSeconds(delayTime);
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Count)
            {
                waypoints.Reverse();
                currentWaypoint = 0;
            }

            onStop = false;
        }
        
    }
}


