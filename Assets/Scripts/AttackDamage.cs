using System;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public float damage;
    void Start()
    {
        //damage = GetComponent<PlayerAttacks>().
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //other.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
    }
}
