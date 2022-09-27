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

    public Camera cam;

    void Start()
    {
        
    }

    void ScreenBounds()
    {
        float mapX = 100.0f;
        float mapY = 100.0f;

        float minX;
        float maxX;
        float minY;
        float maxY;
        
        float vertExtent = Camera.main.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;
 
        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
        
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            timer = 0f;
            //GameObject enemy = Instantiate(enemyPrefab, spawnPos.position, quaternion.identity);
            //enemyPoses.Add(enemy.transform);
        }
    }
    
}
