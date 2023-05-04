using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    //ElevatorMovement and ElevatorTrigger both originated from this video: https://www.youtube.com/watch?v=cW-5JYZLlvQ
    public bool Floor1;
    public bool Floor2;
    public bool Floor3;

    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;

    void Start()
    {
        transform.position = points[startPoint].position;
    }

    private void FixedUpdate()
    {
        if (Floor1)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);

            if (transform.position == points[1].position)
            {
                Floor1 = false;
            }
        }

        if (Floor2)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[2].position, speed * Time.deltaTime);

            if (transform.position == points[2].position)
            {
                Floor2 = false;
            }
        }

        if (Floor3)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[3].position, speed * Time.deltaTime);

            if (transform.position == points[3].position)
            {
                Floor3 = false;
            }
        }
    }
}