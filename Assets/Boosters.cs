using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boosters : MonoBehaviour
{

    private Transform name;
    private Transform description;
    private Transform level;

    public UpgradeWeapons Weapons;
    public UpgradeWeapons ShotGun;
    public UpgradeWeapons Orbital;
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.transform.GetChild(0);
        description = gameObject.transform.GetChild(1);
        level = gameObject.transform.GetChild(2);
        Weapons = ShotGun;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Weapons = Orbital;
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            if(gameObject.name == "Boost1")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[0].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[0].description;
                level.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[0].level;
            }
            if(gameObject.name == "Boost2")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[1].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[1].description;
                level.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[1].level;
            }
            if(gameObject.name == "Boost3")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[2].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[2].description;
                level.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[2].level;
            }
        }
    }
}
