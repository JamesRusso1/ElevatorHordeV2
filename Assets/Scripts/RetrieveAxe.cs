using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveAxe : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Axe;
    public GameObject RetrieveAxeCanvas;
    public GameObject StaticAxe;

    public GameObject[] WinTriggers;
    public GameObject[] Enemies;

    public AudioSource Ding;

    public RangeScript RS1;
    public RangeScript RS2;
    public RangeScript RS3;
    public RangeScript RS4;
    public RangeScript RS5;

    private void Start()
    {
        RS1 = FindObjectOfType<RangeScript>();
        RS2 = FindObjectOfType<RangeScript>();
        RS3 = FindObjectOfType<RangeScript>();
        RS4 = FindObjectOfType<RangeScript>();
        RS5 = FindObjectOfType<RangeScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RetrieveAxeCanvas.SetActive(true);
        }

        if (RS1.Entered == true || RS2.Entered == true || RS3.Entered == true || RS4.Entered == true || RS5.Entered == true)
        {
            Ding.Play();
            if (Input.GetKey(KeyCode.F))
            {
                Sword.SetActive(false);
                Axe.SetActive(true);
                StaticAxe.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RetrieveAxeCanvas.SetActive(false);
    }
}