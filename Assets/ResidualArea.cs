using System;
using UnityEngine;

public class ResidualArea : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //burns the enemy
            col.GetComponent<Enemy>().burnTimer = 3;
            //tells the enemy how much damage it should take every second
            col.GetComponent<Enemy>().burnDamage = damage;
        }
    }
}
