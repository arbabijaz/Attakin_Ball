using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemyPreeFab;
    public float range;
    public int totalPlayer;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalPlayer; i++)
        {
            Instantiate(enemyPreeFab, GenerateSpawnPos(), enemyPreeFab.transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnposX = Random.Range(-range, range);
        float spawnposZ = Random.Range(-range, range);
        Vector3 spawnPos = new Vector3(spawnposX, 0, spawnposZ);
        return spawnPos;
    }
}
