using System.Collections;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public bool canDamage;
    public int damage = 5;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        canDamage = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
    }
}
