using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaOfDamage : MonoBehaviour
{
    public int damage = 5;
    private float recoilForce = 10;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= damage;
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
