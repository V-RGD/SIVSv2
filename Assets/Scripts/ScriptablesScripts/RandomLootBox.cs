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

    public LootScripts TheLoot;

    // Start is called before the first frame update
    void Start()
    {
        PanelLootBox.SetActive(false);
        name = gameObject.transform.GetChild(0);
        description = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
           PanelLootBox.SetActive(true);
           IndexLootBox = Random.Range(0,3);
           Debug.Log(IndexLootBox);
           ChargeLootBox();
        }
    }

    void ChargeLootBox()
    {
        name.transform.GetChild(0).GetComponent<Text>().text = TheLoot.theLootBox[IndexLootBox].name;
        description.transform.GetChild(0).GetComponent<Text>().text = TheLoot.theLootBox[IndexLootBox].description;
    }

    public void ApplyLootBox()
    {
        PanelLootBox.SetActive(false);
        if(IndexLootBox == 0)
        {
            Debug.Log("Amélioration 1");
        }
        if(IndexLootBox == 1)
        {
            Debug.Log("Amélioration 2");
        }
        if(IndexLootBox == 2)
        {
            Debug.Log("Amélioration 3");
        }
    }
}
