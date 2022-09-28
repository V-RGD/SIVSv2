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
                Debug.Log("Damage");
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("Radius");
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("Cadence");
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

        // Spe1
        if(BarName == "LevelBar1")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1");
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2");
            }
        }
    }
}
