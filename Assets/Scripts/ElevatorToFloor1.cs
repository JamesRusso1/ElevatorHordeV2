using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorToFloor1 : MonoBehaviour
{
    [SerializeField] GameObject Floor1ButtonCanvas;

    ElevatorMovement moving;

    private void Start()
    {
        moving = FindObjectOfType<ElevatorMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Floor1ButtonCanvas.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            moving.Floor1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Floor1ButtonCanvas.SetActive(false);
    }
}