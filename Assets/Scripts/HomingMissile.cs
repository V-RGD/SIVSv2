using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector2 rotationDiff;
    public PlayerAttacks p_a;
    public bool canDamage;
    public int damage = 5;
    public GameObject Aoe;
    public bool canMove = true;
    private void Start()
    {
        p_a = GameObject.Find("Player").GetComponent<PlayerAttacks>();
        if (target != null)
        {
            transform.right = (target.transform.position - transform.position);
        }
        Aoe = transform.GetChild(0).gameObject;
        canDamage = true;
    }

    private void FixedUpdate()
    {
        FindClosestEnemy();
        //si un ennemy est à l'écran
        if (target != null && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.right = target.position - transform.position;
        }
    }
    
    void FindClosestEnemy()
    {
        if (p_a.enemyPoses.Length != 0)
        {
            //takes the closest one from the missile
            target = GetClosestEnemy(p_a.enemyPoses);
        }
    }
    
    Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            if (potentialTarget != null)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }
     
        return bestTarget;
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
        canMove = false;   
        GetComponent<SpriteRenderer>().enabled = false;
        Aoe.SetActive(true);
        Aoe.GetComponent<AreaOfDamage>().damage = damage;
        yield return new WaitForSeconds(1);
        Aoe.SetActive(false);
        Destroy(gameObject);
    }
}
