using TMPro;
using UnityEngine;

public class AreaOfDamage : MonoBehaviour
{
    public float damage = 5;
    private float recoilForce = 10;
    public float radius;

    private void Start()
    {
        transform.localScale = new Vector3(radius, radius, radius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= damage;
            other.GetComponent<Enemy>().RecoilTampon(other.transform.position - transform.position);
            //pop up UI
            GameObject ui = Instantiate(other.GetComponent<Enemy>().damageUI, other.transform);
            ui.transform.position = Vector3.zero;
            ui.SetActive(true);
            ui.GetComponent<Animator>().SetTrigger("DamageTaken");
            ui.GetComponent<TMP_Text>().text = damage.ToString();
            //other.GetComponent<Rigidbody2D>().AddForce(-(player.transform.position - transform.position).normalized * recoilForce);
        }
    }
}
