using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //all variables i need 
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject enemy;

    private float timer;

    private void Start()
    {
        SpawnPipe(); //start spawn at start
    }

    private void Update()
    {
        if (timer > maxTime) //if the timer runs out spawn 
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange)); //configure spawn point related to heightrange
        GameObject pipe = Instantiate(enemy, spawnPos, Quaternion.identity);//spawn the enemy
         
       
    }

}
