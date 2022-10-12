using System.Collections;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public bool canDamage;
    public bool canSpawnShrapnel = true;
    public float damage = 5;
    public float radius = 2;
    public float damageCoef;
    public float radiusCoef;
    public int shrapnelDamage;
    public GameObject Aoe;

    public bool isShrapnel;
    public bool isIce;
    public GameObject shrapnel;

    public GameObject iceZone;
    public GameObject camera;

    public bool autoExplode;

    public Animator explosionMine;
    public GameObject mineExplosion;
    IEnumerator Start()
    {
        camera = GameObject.Find("CM vcam1");
        Aoe = transform.GetChild(0).gameObject;
        canDamage = true;
        iceZone = transform.GetChild(1).gameObject;
        Aoe.GetComponent<AreaOfDamage>().damage = damage * damageCoef;
        Aoe.GetComponent<AreaOfDamage>().radius = radius * radiusCoef;
        yield return new WaitForSeconds(10);
        autoExplode = true;
        canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((canDamage && other.gameObject.CompareTag("Enemy")) || autoExplode)
        {
            canDamage = false;
            StartCoroutine(AreaOfDamage());
            if (isShrapnel && canSpawnShrapnel)
            {
                canSpawnShrapnel = false;
                ShrapnelsSpawn();
            }
            if (isIce)
            {
                StartCoroutine(ResidualZone());
            }
        }
    }

    IEnumerator AreaOfDamage()
    {
        //anim
        mineExplosion.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        Aoe.SetActive(true);
        Aoe.GetComponent<AreaOfDamage>().damage = damage;
        yield return new WaitForSeconds(1);
        Aoe.SetActive(false);
        if (!isIce)
        {
            Destroy(gameObject);
        }
    }

    void ShrapnelsSpawn()
    {
        float rotationDiff = 90;
        //instanciate X projo separated by Y angle, does Z damage, dissapears after W range
        for (int i = 0; i < 4; i++)
        {
            Vector2 rotateDir = Vector2.right;
            GameObject projo = Instantiate(shrapnel, transform.position, Quaternion.identity);
            rotateDir = Quaternion.Euler(0, 0, rotationDiff) * Vector2.right;
            projo.GetComponent<Rigidbody2D>().AddForce(rotateDir * 100);
            projo.GetComponent<AttackDamage>().damage = damage;
            
            rotationDiff += 90;
        }
    }
    
    IEnumerator ResidualZone()
    {
        iceZone.SetActive(true);
        yield return new WaitForSeconds(5);
        iceZone.SetActive(false);
        Destroy(gameObject);
    }
}
