using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public float speed = 1.5f;
    public int enemyType;
    public float health;
    public float damage;
    public Spawner spawner;
    
    //public GameObject damageUI;
    
    public float burnTimer;
    private bool canBurn = true;
    public float burnDamage = 1;
    
    public float slowedTimer;
    public float speedCoef = 1;

    public GameObject[] xpDropped;
    private GameObject fireStatus;
    private GameObject iceStatus;
    private GameObject hurtVfx;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool canSpawnXP = true;
    private bool friction;

    public GameObject food;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        fireStatus = transform.GetChild(0).gameObject;
        iceStatus = transform.GetChild(1).gameObject;
        hurtVfx = transform.GetChild(2).gameObject;
        hurtVfx.SetActive(false);
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

        if (friction)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        Flip();
        StatusVFX();
        if (health <= 0)
        {
            Score.instance.currentScore += 1;
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
        
        /*
        GameObject ui = Instantiate(damageUI, transform);
        ui.transform.position = Vector3.zero;
        ui.SetActive(true);
        ui.GetComponent<Animator>().SetTrigger("DamageTaken");
        ui.GetComponent<TMP_Text>().text = burnDamage.ToString();
        */
        yield return new WaitForSeconds(1);
        canBurn = true;
    }

    void LootDrop()
    {
        if (enemyType < 4)
        {
            int randXpDrop = Random.Range(0, 1);
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
            counter--;
        }

        if (counter == 0)
        {
            Destroy(gameObject);
        }
    }


    void Flip()
    {
        //Flips the sprite when turning around
        if (player.transform.position.x - transform.position.x > 0.1f)
        {
            sprite.flipX = false;
        }

        else if (player.transform.position.x - transform.position.x < -0.1f)
        {
            sprite.flipX = true;
        }
    }

    void StatusVFX()
    {
        if (burnTimer > 0)
        {
            fireStatus.SetActive(true);
        }
        else
        {
            fireStatus.SetActive(false);
        }
        if (speedCoef < 1)
        {
            iceStatus.SetActive(true);
        }
        else
        {
            iceStatus.SetActive(false);
        }
    }

    public void RecoilTampon(Vector2 dir)
    {
        StartCoroutine(Recoil(dir));
        StartCoroutine(EnemyBlink());
        StartCoroutine(HurtFX());
    }

    IEnumerator Recoil(Vector2 dir)
    {
        friction = false;
        GetComponent<Rigidbody2D>().AddForce(dir * 500);
        yield return new WaitForSeconds(0.2f);
        friction = true;
        yield return new WaitForSeconds(1);
        friction = false;
    }
    
    IEnumerator EnemyBlink()
    {
        for (int i = 0; i < 2; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator HurtFX()
    {
        hurtVfx.SetActive(true);
        yield return new WaitForSeconds(2);
        hurtVfx.SetActive(false);
    }
}
