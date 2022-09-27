using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public int damage = 5;
    public GameObject player;
    public bool isShield;
    private float recoilForce = 10;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if ((player.transform.position - transform.position).magnitude > 40)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isShield)
        {
            other.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
            //other.GetComponent<Rigidbody2D>().AddForce(-(player.transform.position - transform.position).normalized * recoilForce);
            //la roquette n'inflige pas de dégâts mais la zone d'impact oui
        }
    }
}
