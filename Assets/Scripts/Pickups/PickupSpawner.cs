using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject rocketPickup, shieldPickup, magnetizePickup;
    public float powerSpawnTime = 1;
    public float powerSpawnDistance = 10f;

    private void Start()
    {
        StartCoroutine(SpawnPower());
    }

    private IEnumerator SpawnPower()
    {
        int r = 0;
        Vector3 spawnPos = Vector3.zero;
        while (true)
        {
            yield return new WaitForSeconds(powerSpawnTime);
            r = Random.Range(1, 100);
            spawnPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + powerSpawnDistance);
            if(CompareTag("Player"))
            {
                Vector3 addPos = new Vector3(Random.Range(-.5f, .5f), 0, 0);
                spawnPos += addPos;
            }
            if (r < 40)
            {
                Instantiate(rocketPickup, spawnPos, Quaternion.identity);
            }
            else if (r < 20)
            {
                Instantiate(magnetizePickup, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(shieldPickup, spawnPos, Quaternion.identity);
            }
        }
    }
}
