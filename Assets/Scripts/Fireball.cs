using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 12f;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var Basketball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            Basketball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
        }
    }
}
