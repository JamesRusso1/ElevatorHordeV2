using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeScript : MonoBehaviour
{
    public GameObject Enemy;
    public bool Entered;

    private void OnTriggerEnter(Collider other)
    {
            Entered = true;
    }
}