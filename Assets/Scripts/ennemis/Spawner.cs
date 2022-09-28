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
    public List<GameObject> enemiesInGame;
    public List<Transform> enemyPoses;
    public Camera cam;

    private float greenTimer;
    private float yellowTimer;
    private float orangeTimer;
    private float redTimer;
    private float blueTimer;
    private float goldenTimer = 120;

    public bool canSpawnGreen;
    public bool canSpawnYellow;
    public bool canSpawnOrange;
    public bool canSpawnRed;
    public bool canSpawnBlue;
    public bool canSpawnGolden;

    public List<int> greenWaves;
    public List<int> yellowWaves;
    public List<int> orangeWaves;
    public List<int> redWaves;
    public List<int> blueWaves;
    public List<int> goldenWaves;

    public int currentWave;
    public float waveTimer;

    public int[] enemyHealths = new []{1, 4, 16, 32, 56};
    public int[] H_Upgrades = new []{2, 4, 6, 8, 10};
    //damage increase each 30S
    public int[] enemyDamages = new []{4, 5, 6, 7, 8};

    private int[] goldenHealths = new []{50, 100, 150, 200, 250, 300};

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
        blueTimer -= Time.deltaTime;
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

        //-----------BLUE------------
        if (blueWaves.Contains(currentWave))
        {
            canSpawnBlue = true;
        }
        else
        {
            canSpawnBlue = false;
        }
        
        //--------------DORE------------
        if (goldenWaves.Contains(currentWave))
        {
            canSpawnGolden = true;
        }
        
        goldenTimer += Time.deltaTime;
    }
    #endregion

    void DinoSpawners()
    {
        if (greenTimer <= 0 && canSpawnGreen)
        {
            greenTimer = 1 / spawnRate;
            EnemySpawn(0);
        }

        if (yellowTimer <= 0 && canSpawnYellow)
        {
            yellowTimer = 1 / spawnRate;
            EnemySpawn(1);
        }

        if (orangeTimer <= 0 && canSpawnOrange)
        {
            orangeTimer = 1 / spawnRate;         
            EnemySpawn(2);
        }

        if (redTimer <= 0 && canSpawnRed)
        {
            redTimer = 1 / spawnRate;
            EnemySpawn(3);
        }

        if (blueTimer <= 0 && canSpawnBlue)
        {
            blueTimer = 1 / spawnRate;
            EnemySpawn(4);
        }

        if (goldenTimer <= 0)
        {
            goldenTimer = 180;
            EnemySpawn(5);
        }
    }

    void EnemySpawn(int enemyType)
    {
        Vector2 spawnPoint = Vector2.zero;
        int randDir = Random.Range(0, 4);
        #region randomise dir
        if (randDir == 0)
        {
            //spawns down
            spawnPoint = new Vector2( -cameraLenght/2 + (Random.Range(0, 100) / 100 * cameraLenght), -cameraHeight);
        }
        if (randDir == 1)
        {
            //spawns left
            spawnPoint = new Vector2( -cameraLenght, -cameraHeight/2 + (Random.Range(0, 100) / 100 * cameraHeight));
        }
        if (randDir == 2)
        {
            //spawns up
            spawnPoint = new Vector2(-cameraLenght/2 + (Random.Range(0, 100) / 100 * cameraLenght), cameraHeight);
        }
        if (randDir == 3)
        {
            //spawns right
            spawnPoint = new Vector2( cameraLenght, -cameraHeight/2 + (Random.Range(0, 100) / 100 * cameraHeight));
        }
        spawnPoint += new Vector2(player.transform.position.x, player.transform.position.y);
        #endregion
        GameObject enemyToSpawn = Instantiate(enemyPrefabs[enemyType], spawnPoint, quaternion.identity);
        enemyToSpawn.GetComponent<Enemy>().health = enemyHealths[enemyType] + currentWave * H_Upgrades[enemyType];
        enemyToSpawn.GetComponent<Enemy>().damage = enemyDamages[enemyType];
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
