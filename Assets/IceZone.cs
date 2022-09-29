using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZone : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //slows the enemy
            col.GetComponent<Enemy>().slowedTimer = 3;
        }
    }
}
