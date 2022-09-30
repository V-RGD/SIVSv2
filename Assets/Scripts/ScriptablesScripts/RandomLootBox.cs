using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLootBox : MonoBehaviour
{
    private int IndexLootBox;
    public GameObject PanelLootBox;
    public Transform name;
    public Transform description;
    public Transform icon;
    public Transform Childname;
    public Transform ChildDescription;
    private GameObject player;
    private GameObject TheGameManager;

    public LootScripts TheLoot;


     public static RandomLootBox instance;
     private void Awake()
    {
            if (instance != null)
            {
              return;
            }
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PanelLootBox.SetActive(false);
        Childname = name.transform.GetChild(0);
        ChildDescription = description.transform.GetChild(0);
        player = GameObject.Find("Player");
        TheGameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
     /*  if(Input.GetKeyDown(KeyCode.Keypad6))
        {
           OpenLootBox();
        } */
    }

    public void OpenLootBox()
    {
        Time.timeScale = 0;
        PanelLootBox.SetActive(true);
        IndexLootBox = Random.Range(0,3);
        Debug.Log(IndexLootBox);
        ChargeLootBox();
    }
    public void ChargeLootBox()
    {
        Childname.GetComponent<Text>().text = TheLoot.theLootBox[IndexLootBox].name;
        ChildDescription.GetComponent<Text>().text = TheLoot.theLootBox[IndexLootBox].description;
        icon.GetComponent<Image>().sprite = TheLoot.theLootBox[IndexLootBox].icon;
    }

    public void ApplyLootBox()
    {
        Time.timeScale = 1;
        PanelLootBox.SetActive(false);
        Time.timeScale = 1;
        if(IndexLootBox == 0)
        {
            Debug.Log("MaxSpeed");
            player.GetComponent<PlayerController>().maxSpeed += 1;
        }
        if(IndexLootBox == 1)
        {
            Debug.Log("MaxHP");
            TheGameManager.GetComponent<GameManager>().maxHealth += 20;
        }
        if(IndexLootBox == 2)
        {
            Debug.Log("Dégats");
            player.GetComponent<PlayerController>().maxSpeed += 1;
            player.GetComponent<PlayerAttacks>().shotgunDamage += 1;
            player.GetComponent<PlayerAttacks>().mineDamage += 1;
            player.GetComponent<PlayerAttacks>().shieldDamage += 1f;
        }
    }
}
