using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 3;
    public EnemyType enemyType;
    public float health;
    public float damage;
    public Spawner spawner;

    public GameObject damageUI;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        if (health <= 0)
        {
            spawner.enemyPoses.Remove(gameObject.transform);
            Destroy(gameObject);
        }
    }
}
