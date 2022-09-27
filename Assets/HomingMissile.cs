using System;
using UnityEngine;
public class HomingMissile : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public bool isRocket = true;
    public Vector2 rotationDiff;
    private void Start()
    {
        if (!isRocket)
        {
            transform.right = (enemy.transform.position - transform.position);
            //transform.Rotate(rotationDiff);
        }
    }

    private void FixedUpdate()
    {
        if (isRocket)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
            transform.right = enemy.transform.position - transform.position;
        }
    }
}
