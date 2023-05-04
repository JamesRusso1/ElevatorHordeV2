using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorToFloor2 : MonoBehaviour
{
    [SerializeField] GameObject Floor2ButtonCanvas;

    ElevatorMovement moving;

    private void Start()
    {
        moving = FindObjectOfType<ElevatorMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Floor2ButtonCanvas.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            moving.Floor2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Floor2ButtonCanvas.SetActive(false);
    }
}