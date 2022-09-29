using System.Collections;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public bool canDamage;
    public int damage = 5;
    public int shrapnelDamage;
    public GameObject Aoe;

    public bool isShrapnel;
    public bool isIce;
    public GameObject shrapnel;

    public GameObject iceZone;
    IEnumerator Start()
    {
        Aoe = transform.GetChild(0).gameObject;
        canDamage = true;
        iceZone = transform.GetChild(1).gameObject;
        yield return new WaitForSeconds(10);
        StartCoroutine(AreaOfDamage());
        canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.gameObject.CompareTag("Enemy"))
        {
            canDamage = false;
            StartCoroutine(AreaOfDamage());
            if (isShrapnel)
            {
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
            projo.GetComponent<AttackDamage>().damage = shrapnelDamage;
            
            rotationDiff += 90;
        }
    }
    
    IEnumerator ResidualZone()
    {
        Debug.Log("ice spawned");
        iceZone.SetActive(true);
        yield return new WaitForSeconds(5);
        iceZone.SetActive(false);
        Destroy(gameObject);
    }
}
