using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    private float timer;
    
    private Vector3 spawnVector;
    public List<Transform> enemyPoses;
    public Camera cam;

    private float greenTimer;
    private float yellowTimer;
    private float orangeTimer;
    private float redTimer;
    public float goldenTimer = 0;

    public bool canSpawnGreen;
    public bool canSpawnYellow;
    public bool canSpawnOrange;
    public bool canSpawnRed;
    public bool canSpawnGolden;
    public bool canSpawnBoss = true;

    public List<int> greenWaves;
    public List<int> yellowWaves;
    public List<int> orangeWaves;
    public List<int> redWaves;
    public List<int> goldenWaves;

    public int currentWave;
    public float waveTimer;

    public int[] enemyHealths = new []{1, 4, 16, 32, 56};
    public int[] H_Upgrades = new []{2, 4, 6, 8, 10};
    //damage increase each 30S
    public int[] enemyDamages = new []{4, 5, 6, 7, 8};

    private int[] goldenHealths = new []{50, 100, 150, 200, 250, 300};
    private int[] goldenDamages = new []{5, 10, 15, 20, 25, 30};
    private int goldenToSpawn = 1;

    private float cameraHeight;
    private float cameraLenght;

    public GameObject[] enemyPrefabs;
    
    private GameObject player;

    private float spawnXoffset = 5;
    private float spawnYoffset = 5;

    void Start()
    {
        CheckCameraSize();
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;
        greenTimer -= Time.deltaTime;
        yellowTimer -= Time.deltaTime;
        orangeTimer -= Time.deltaTime;
        redTimer -= Time.deltaTime;
        goldenTimer -= Time.deltaTime;

        ColorActivations();
        DinoSpawners();
    }
    #region ColorDinoActivations
    void ColorActivations()
    {
        if (waveTimer >= 30)
        {
            waveTimer = 0;
            currentWave++;
        }

        if (currentWave >= 40)
        {
            currentWave = 40;
        }

        if (currentWave < 40)
        {
            //-------VERT------------
            if (greenWaves.Contains(currentWave))
            {
                canSpawnGreen = true;
            }
            else
            {
                canSpawnGreen = false;
            }

            //------------JAUNE-----------
            if (yellowWaves.Contains(currentWave))
            {
                canSpawnYellow = true;
            }
            else
            {
                canSpawnYellow = false;
            }

            //----------------ORANGE------
            if (orangeWaves.Contains(currentWave))
            {
                canSpawnOrange = true;
            }
            else
            {
                canSpawnOrange = false;
            }

            //--------------Rouge------------
            if (redWaves.Contains(currentWave))
            {
                canSpawnRed = true;
            }
            else
            {
                canSpawnRed = false;
            }
        }
        else
        {
            canSpawnGreen = true;
            canSpawnYellow = true;
            canSpawnOrange = true;
            canSpawnRed = true;
            if (canSpawnBoss)
            {
                canSpawnBoss = false;
                EnemySpawn(6);
            }
        }

        //--------------DORE------------
        if (goldenWaves.Contains(currentWave))
        {
            canSpawnGolden = true;
        }
    }
    #endregion
    #region SpawnTimers
    void DinoSpawners()
    {
        if (greenTimer <= 0 && canSpawnGreen)
        {
            greenTimer = 1 / spawnRate;
            EnemySpawn(0);
            
            int lgbtDinoSpawn = Random.Range(0, 1000);
            if (lgbtDinoSpawn == 69)
            {
                EnemySpawn(4);
                Debug.Log("GAY DINO WOO");
            }
        }

        if (yellowTimer <= 0 && canSpawnYellow)
        {
            yellowTimer = 1 / spawnRate;
            EnemySpawn(1);
            
            int lgbtDinoSpawn = Random.Range(0, 1000);
            if (lgbtDinoSpawn == 69)
            {
                EnemySpawn(4);
                Debug.Log("GAY DINO WOO");
            }
        }

        if (orangeTimer <= 0 && canSpawnOrange)
        {
            orangeTimer = 1 / spawnRate;         
            EnemySpawn(2);
            
            int lgbtDinoSpawn = Random.Range(0, 1000);
            if (lgbtDinoSpawn == 69)
            {
                EnemySpawn(4);
                Debug.Log("GAY DINO WOO");
            }
        }

        if (redTimer <= 0 && canSpawnRed)
        {
            redTimer = 1 / spawnRate;
            EnemySpawn(3);
            
            int lgbtDinoSpawn = Random.Range(0, 1000);
            if (lgbtDinoSpawn == 69)
            {
                EnemySpawn(4);
                Debug.Log("GAY DINO WOO");
            }
        }

        if (goldenTimer <= 0)
        {
            goldenTimer = 180;
            goldenToSpawn++;
            Debug.Log("golden dino spawned");
            EnemySpawn(5);
        }
    }
    #endregion
    void EnemySpawn(int enemyType)
    {
        Vector2 spawnPoint = Vector2.zero;
        int randDir = Random.Range(0, 4);
        float randPos = Random.Range(0, 100);
        randPos = randPos / 100;
        #region randomise dir
        if (randDir == 0)
        {
            //spawns down
            spawnPoint = new Vector2( -cameraLenght/2 + ( randPos * cameraLenght), -cameraHeight);
        }
        if (randDir == 1)
        {
            //spawns left
            spawnPoint = new Vector2( -cameraLenght, -cameraHeight/2 + (randPos * cameraHeight));
        }
        if (randDir == 2)
        {
            //spawns up
            spawnPoint = new Vector2(-cameraLenght/2 + (randPos * cameraLenght), cameraHeight);
        }
        if (randDir == 3)
        {
            //spawns right
            spawnPoint = new Vector2( cameraLenght, -cameraHeight/2 + (randPos * cameraHeight));
        }
        spawnPoint += new Vector2(player.transform.position.x, player.transform.position.y);
        #endregion
        GameObject enemyToSpawn = Instantiate(enemyPrefabs[enemyType], spawnPoint, quaternion.identity);
        if (enemyType == 5)
        {
            enemyToSpawn.GetComponent<Enemy>().health = goldenHealths[goldenToSpawn];
            enemyToSpawn.GetComponent<Enemy>().damage = goldenDamages[goldenToSpawn];
        }
        else if (enemyType == 6)
        {
            enemyToSpawn.GetComponent<Enemy>().health = 1000;
            enemyToSpawn.GetComponent<Enemy>().damage = 999;
            enemyToSpawn.GetComponent<Enemy>().speed = 2;
        }
        else
        {
            enemyToSpawn.GetComponent<Enemy>().health = enemyHealths[enemyType] + currentWave * H_Upgrades[enemyType];
            enemyToSpawn.GetComponent<Enemy>().damage = enemyDamages[enemyType];
        }
        enemyToSpawn.GetComponent<Enemy>().spawner = this;
        enemyPoses.Add(enemyToSpawn.transform);
    }

    void CheckCameraSize()
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

        cameraHeight = vertExtent + spawnYoffset;
        cameraLenght = horzExtent + spawnXoffset;
    }
}
