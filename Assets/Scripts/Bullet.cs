using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public PlayerAttacks p_a;
    private Transform[] enemyPoses;
    public int damage = 5;
    public bool isPiercing;
    private void Start()
    {
        p_a = GameObject.Find("Player").GetComponent<PlayerAttacks>();
    }

    private void FixedUpdate()
    {
        enemyPoses = p_a.enemyPoses;
    }
}
