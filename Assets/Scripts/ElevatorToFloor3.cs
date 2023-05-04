using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorToFloor3 : MonoBehaviour
{
    [SerializeField] GameObject Floor3ButtonCanvas;

    ElevatorMovement moving;

    private void Start()
    {
        moving = FindObjectOfType<ElevatorMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Floor3ButtonCanvas.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            moving.Floor3 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Floor3ButtonCanvas.SetActive(false);
    }
}