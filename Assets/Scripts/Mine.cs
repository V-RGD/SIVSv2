using System.Collections;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public bool canDamage;
    public int damage = 5;
    public GameObject Aoe;
    IEnumerator Start()
    {
        Aoe = transform.GetChild(0).gameObject;
        yield return new WaitForSeconds(2);
        canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.gameObject.CompareTag("Enemy"))
        {
            canDamage = false;
            StartCoroutine(AreaOfDamage());
        }
    }

    IEnumerator AreaOfDamage()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Aoe.SetActive(true);
        Aoe.GetComponent<AreaOfDamage>().damage = damage;
        yield return new WaitForSeconds(1);
        Aoe.SetActive(false);
        Destroy(gameObject);
    }
}
