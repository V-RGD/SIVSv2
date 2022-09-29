using System;
using UnityEngine;
public class HomingMissile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isRocket = true;
    public Vector2 rotationDiff;
    public PlayerAttacks p_a;
    private Transform[] enemyPoses;
    private void Start()
    {
        p_a = GameObject.Find("Player").GetComponent<PlayerAttacks>();
        if (!isRocket && target != null)
        {
            transform.right = (target.transform.position - transform.position);
        }
    }

    private void FixedUpdate()
    {
        enemyPoses = p_a.enemyPoses;
        FindClosestEnemy();
        //si un ennemy est à l'écran
        if (target != null && isRocket)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.right = target.transform.position - transform.position;
        }
    }
    
    void FindClosestEnemy()
    {
        if (enemyPoses.Length != 0)
        {
            //takes the closest one from the missile
            //target = GetClosestEnemy(enemyPoses).gameObject;
        }
    }
    
    Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }
}
