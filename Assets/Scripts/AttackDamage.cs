using TMPro;
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
        //if it's neither a missile nor a mine
        if ((player.transform.position - transform.position).magnitude > 40)
        {
            Destroy(gameObject);
        }

        if (GetComponent<HomingMissile>() != null && (player.transform.position - transform.position).magnitude <= 1)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isShield)
        {
            other.GetComponent<Enemy>().health -= damage;
            //pop up UI
            GameObject ui = Instantiate(other.GetComponent<Enemy>().damageUI, other.transform);
            ui.transform.position = Vector3.zero;
            ui.SetActive(true);
            ui.GetComponent<Animator>().SetTrigger("DamageTaken");
            ui.GetComponent<TMP_Text>().text = damage.ToString();

            Destroy(gameObject);
            //other.GetComponent<Rigidbody2D>().AddForce(-(player.transform.position - transform.position).normalized * recoilForce);
            //la roquette n'inflige pas de dégâts mais la zone d'impact oui
        }
    }
}
