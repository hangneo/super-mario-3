using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTurtleTienDat : MonoBehaviour
{
    public Transform[] waypoint;
    float moveSpeed = 5f;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoint[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FlyTrutleMove();
    }
    void FlyTrutleMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint[wayPointIndex].position, moveSpeed * Time.deltaTime);
        if (transform.position == waypoint[wayPointIndex].position)
        {
            wayPointIndex++;
        }
        if (wayPointIndex == waypoint.Length)
        {
            wayPointIndex = 0;
        }
    }
}
