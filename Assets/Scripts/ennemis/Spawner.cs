using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public float spawnInterval;
    private float timer;

    private Vector3 spawnVector;

    public List<Transform> enemyPoses;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            timer = 0f;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos.position, quaternion.identity);
            enemyPoses.Add(enemy.transform);
        }
    }
    
}
