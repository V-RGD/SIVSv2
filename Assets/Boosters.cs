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
    public UpgradeWeapons Mine;
    public UpgradeWeapons Missile;
    public UpgradeWeapons Orbital;
    public UpgradeWeapons Tronc;

    public string BarName;

     // Singelton
     public static Boosters instance;
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
        name = gameObject.transform.GetChild(0);
        description = gameObject.transform.GetChild(1);
        level = gameObject.transform.GetChild(2);
        Weapons = ShotGun;
    }

    public void RefreshBar()
    {
        if(BarName == "LevelBar1")
        {
            Weapons = ShotGun;
        }
        if(BarName == "LevelBar2")
        {
            Weapons = Mine;
        }
        if(BarName == "LevelBar3")
        {
            Weapons = Missile;
        }
        if(BarName == "LevelBar4")
        {
            Weapons = Orbital;
        }
        if(BarName == "LevelBar5")
        {
            Weapons = Tronc;
        }
    }
   public void RefreshSelectPanel()
   {
    if(gameObject.name == "Boost1")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[0].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[0].description;
                level.transform.GetChild(0).GetComponent<Text>().text = "" + Weapons.TheStats[0].niveau;
            }
    if(gameObject.name == "Boost2")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[1].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[1].description;
                level.transform.GetChild(0).GetComponent<Text>().text = "" + Weapons.TheStats[1].niveau;
            }
    if(gameObject.name == "Boost3")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[2].name;
                description.transform.GetChild(0).GetComponent<Text>().text = Weapons.TheStats[2].description;
                level.transform.GetChild(0).GetComponent<Text>().text = "" + Weapons.TheStats[2].niveau;
            }
   } 

   public void FirstChoice()
   {
     Weapons.TheStats[0].niveau += 1;
   }
      public void SecondChoice()
   {
     Weapons.TheStats[1].niveau += 1;
   }
         public void LastChoice()
   {
     Weapons.TheStats[2].niveau += 1;
   }
}
