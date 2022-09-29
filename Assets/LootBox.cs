using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public Animator animator;
    public AudioClip ChestBox;
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
        if(col.gameObject.CompareTag("Player"))
        {
          AudioManager.instance.PlayClipAt(ChestBox, transform.position);
          animator.SetBool("isOpening",true);
          RandomLootBox.instance.OpenLootBox();
          gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
