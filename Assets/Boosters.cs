using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boosters : MonoBehaviour
{

    public Transform name;
    public Transform description;
    public Transform level;

    public UpgradeWeapons Weapons;
    public UpgradeWeapons ShotGun;
    public UpgradeWeapons Mine;
    public UpgradeWeapons Missile;
    public UpgradeWeapons Orbital;
    public UpgradeWeapons Tronc;

    public Specialization TheSpe;
    public Specialization SpeShotGun;
    public Specialization SpeMine;
    public Specialization SpeMissile;
    public Specialization SpeOrbital;
    public Specialization SpeTronc;

    public string BarName;

    // Est-ce qu'il est au niveau 5
    private bool isLevel5;

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
            if(NumberOfUpdates.instance.TiersShotGun == 4)
            {
                isLevel5 = true;
                Debug.Log("On passe au niveau 5");
                TheSpe = SpeShotGun;
            }
            else
            {
              Weapons = ShotGun;
              isLevel5 = false;
            }
        }
        if(BarName == "LevelBar2")
        {
            if(NumberOfUpdates.instance.TiersMine == 4)
            {
                isLevel5 = true;
                Debug.Log("On passe au niveau 5");
                TheSpe = SpeMine;
            }
            else
            {
              Weapons = Mine;
              isLevel5 = false;
            }
        }
        if(BarName == "LevelBar3")
        {
            if(NumberOfUpdates.instance.TiersMissile == 4)
            {
                isLevel5 = true;
                Debug.Log("On passe au niveau 5");
                TheSpe = SpeMissile;
            }
            else
            {
              Weapons = Missile;
              isLevel5 = false;
            }
        }
        if(BarName == "LevelBar4")
        {
            if(NumberOfUpdates.instance.TiersOrbital == 4)
            {
                isLevel5 = true;
                Debug.Log("On passe au niveau 5");
                TheSpe = SpeOrbital;
            }
            else
            {
              Weapons = Orbital;
              isLevel5 = false;
            }
        }
        if(BarName == "LevelBar5")
        {
            if(NumberOfUpdates.instance.TiersTronc == 4)
            {
                isLevel5 = true;
                Debug.Log("On passe au niveau 5");
                TheSpe = SpeTronc;
            }
            else
            {
              Weapons = Tronc;
              isLevel5 = false;
            }
        }
    }
   public void RefreshSelectPanel()
   {
    if(isLevel5)
    {
        if(gameObject.name == "Spe1")
            {
                Debug.Log("oui");
                name.transform.GetChild(0).GetComponent<Text>().text = TheSpe.SpeTheStats[0].name;
                description.transform.GetChild(0).GetComponent<Text>().text = TheSpe.SpeTheStats[0].description;
            }
        if(gameObject.name == "Spe2")
            {
                name.transform.GetChild(0).GetComponent<Text>().text = TheSpe.SpeTheStats[1].name;
                description.transform.GetChild(0).GetComponent<Text>().text = TheSpe.SpeTheStats[1].description;
            }
    }
    else
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
