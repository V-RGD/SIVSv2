using System;
using UnityEngine;
public class HomingMissile : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public bool isRocket = true;
    public Vector2 rotationDiff;
    public PlayerAttacks p_a;
    private void Start()
    {
        p_a = GameObject.Find("Player").GetComponent<PlayerAttacks>();
        if (!isRocket && enemy != null)
        {
            transform.right = (enemy.transform.position - transform.position);
            //transform.Rotate(rotationDiff);
        }
    }

    private void FixedUpdate()
    {
        if (enemy != null)
        {
            enemy = p_a.target;
            if (isRocket)
            {
                transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
                transform.right = enemy.transform.position - transform.position;
            }
        }
        else
        {
            
        }
    }
}
