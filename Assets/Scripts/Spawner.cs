using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBtwSpawns;
    private float startTimeBtwSpawnsDividedByTwo;

    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float timeDecrease2;
    public float minTime;

    public GameObject[] obstacleTemplate;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        startTimeBtwSpawnsDividedByTwo = startTimeBtwSpawns / 2;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, obstacleTemplate.Length);
            Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime)
            {
                if (startTimeBtwSpawns <= startTimeBtwSpawnsDividedByTwo && startTimeBtwSpawnsDividedByTwo > minTime)
                {
                    startTimeBtwSpawns -= timeDecrease2;
                }
                else
                {
                    startTimeBtwSpawns -= timeDecrease;
                }
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
