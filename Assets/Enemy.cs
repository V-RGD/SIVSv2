using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int health = 1000;

    private float speed = 1;
    private float maxSpeed = 2;

    // Start is called before the first frame update
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
            Destroy(gameObject);
        }
    }
}
