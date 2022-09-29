using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfUpdates : MonoBehaviour
{
    // Number of Tiers
    public int TiersShotGun;
    public int TiersMine;
    public int TiersMissile;
    public int TiersOrbital;
    public int TiersTronc;

    private string BarName;
    private string SpeBarName;
    public string ButtonName;

    public static NumberOfUpdates instance;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TheUpgrades()
    {
        BarName = BoostersParents.instance.TheBar;
        SpeBarName = SpeBoostersParents.instance.TheBar;

        // Barre 1
        if(BarName == "LevelBar1")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageShotGun");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusShotGun");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceShotGun");
            }
        }

        // Barre 2
        if(BarName == "LevelBar2")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageMine");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusMine");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceMine");
            }
        }
        // Barre 3
        if(BarName == "LevelBar3")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("Missile Bonus");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusMissile");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceMissile");
            }
        }
        // Barre 4
        if(BarName == "LevelBar4")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageOrbital");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("SizeOrbital");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("VitesseRotaOrbital");
            }
        }
                // Barre 4
        if(BarName == "LevelBar5")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageTronc");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusTronc");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadencTronc");
            }
        }

        // Spe ShotGun
        if(BarName == "LevelBar1")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1ShotGun");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2ShotGun");
            }
        }
        // Spe Mine
        if(BarName == "LevelBar2")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Mine");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Mine");
            }
        }
        // Spe Missile
        if(BarName == "LevelBar3")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Missile");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Missile");
            }
        }
        // Spe Orbital
        if(BarName == "LevelBar4")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Orbital");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Orbital");
            }
        }
        // Spe Tronc
        if(BarName == "LevelBar5")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Tronc");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Tronc");
            }
        }
    }
}
