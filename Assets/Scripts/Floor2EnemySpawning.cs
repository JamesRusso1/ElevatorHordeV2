using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Floor2EnemySpawning : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent[] Enemies;

    private void Start()
    {
        Enemies = GetComponentsInChildren<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemies[0].speed = 80f;
            Enemies[1].speed = 80f;
            Enemies[2].speed = 80f;
            Enemies[3].speed = 80f;
            Enemies[4].speed = 80f;
            Enemies[5].speed = 80f;
            Enemies[6].speed = 80f;
            Enemies[7].speed = 80f;
            Enemies[8].speed = 80f;
            Enemies[9].speed = 80f;
            Enemies[10].speed = 80f;
            Enemies[11].speed = 80f;
        }
    }
}