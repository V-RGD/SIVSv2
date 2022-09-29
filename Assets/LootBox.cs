using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public Animator animator;
 //   public BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Detect");
        if(col.gameObject.CompareTag("Player"))
        {
          Debug.Log("Player");
          animator.SetBool("isOpening",true);
          RandomLootBox.instance.OpenLootBox();
        }
    }
}
