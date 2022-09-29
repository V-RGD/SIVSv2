using System.Collections;
using TMPro;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public float damage = 5;
    public GameObject player;
    public bool isShield;
    private float recoilForce = 10;
    public bool destroyedOnContact = true;
    public bool isFireAmmo;
    public bool burnDamage;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        //destroy if too far
        if ((player.transform.position - transform.position).magnitude > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isShield)
        {
            other.GetComponent<Enemy>().health -= damage;
            if (isFireAmmo)
            {
                //burns the enemy
                other.GetComponent<Enemy>().burnTimer = 3;
                //tells the enemy how much damage it should take every second
                other.GetComponent<Enemy>().burnDamage = 1;
                //don't forget ui
            }
            
            //pop up UI
            GameObject ui = Instantiate(other.GetComponent<Enemy>().damageUI, other.transform);
            ui.transform.position = Vector3.zero;
            ui.SetActive(true);
            ui.GetComponent<Animator>().SetTrigger("DamageTaken");
            ui.GetComponent<TMP_Text>().text = damage.ToString();

            if (destroyedOnContact)
            {
                Destroy(gameObject);
            }
            //other.GetComponent<Rigidbody2D>().AddForce(-(player.transform.position - transform.position).normalized * recoilForce);
        }
    }

    IEnumerator EnemyBlink(GameObject enemy)
    {
        for (int i = 0; i < 10; i++)
        {
            enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.1f);
            enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
