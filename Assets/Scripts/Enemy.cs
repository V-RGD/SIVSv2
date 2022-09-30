using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public float speed = 3;
    public int enemyType;
    public float health;
    public float damage;
    public Spawner spawner;
    
    public GameObject damageUI;
    
    public float burnTimer;
    private bool canBurn = true;
    public float burnDamage = 1;
    
    public float slowedTimer;
    public float speedCoef = 1;

    public GameObject[] xpDropped;
    private bool canSpawnXP = true;

    public GameObject food;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedCoef * speed * Time.deltaTime);

        if (slowedTimer > 0)
        {
            speedCoef = 0.5f;
        }
        else
        {
            speedCoef = 1;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            spawner.enemyPoses.Remove(gameObject.transform);
            if (canSpawnXP)
            {
                canSpawnXP = false;
                LootDrop();
            }
        }

        if (canBurn && burnTimer > 0)
        {
            canBurn = false;
            StartCoroutine(Burn());
        }

        burnTimer -= Time.deltaTime;
        slowedTimer -= Time.deltaTime;
    }

    IEnumerator Burn()
    {
        health -= burnDamage;
        //pop up UI
        GameObject ui = Instantiate(damageUI, transform);
        ui.transform.position = Vector3.zero;
        ui.SetActive(true);
        ui.GetComponent<Animator>().SetTrigger("DamageTaken");
        ui.GetComponent<TMP_Text>().text = burnDamage.ToString();
        yield return new WaitForSeconds(1);
        canBurn = true;
    }

    void LootDrop()
    {
        if (enemyType < 4)
        {
            int randXpDrop = Random.Range(0, 3);
            if (randXpDrop == 0)
            {
                Instantiate(xpDropped[enemyType], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        //lgbt pinata
        if (enemyType == 4)
        {
            StartCoroutine(Pinata());
        }

        //golden
        if (enemyType == 5)
        {
            Instantiate(xpDropped[4], transform.position, Quaternion.identity);
            
            StartCoroutine(Pinata());
        }

        int randBouffeSpawn = Random.Range(0, 50);
        if (randBouffeSpawn == 0)
        {
            Instantiate(food, transform.position, quaternion.identity);
        }
    }

    IEnumerator Pinata()
    {
        int randAmount = Random.Range(30, 50);
        int counter = randAmount;
        for (int i = 0; i < randAmount; i++)
        {
            int randXpColor = Random.Range(0, 4);
            Instantiate(xpDropped[randXpColor], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            Debug.Log("xp");
            counter--;
        }

        if (counter == 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
