using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 3;
    public EnemyType enemyType;
    public float health;
    public float damage;
    public Spawner spawner;
    
    public GameObject damageUI;
    
    public float burnTimer;
    private bool canBurn = true;
    public float burnDamage = 1;
    
    public float slowedTimer;
    public float speedCoef = 1;

    public GameObject xpDropped;

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
            Instantiate(xpDropped, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
    
    
}
