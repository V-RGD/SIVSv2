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

    private GameObject player;

    // ShotGun
    [HideInInspector] public bool Spe1ShotGun = false;
    [HideInInspector] public bool Spe2ShotGun = false;

    // Mine
    [HideInInspector] public bool Spe1Mine = false;
    [HideInInspector] public bool Spe2Mine = false;

    // Mine
    [HideInInspector] public bool Spe1Missile = false;
    [HideInInspector] public bool Spe2Missile = false;

    // Mine
    [HideInInspector] public bool Spe1Orbital = false;
    [HideInInspector] public bool Spe2Orbital = false;

    // Mine
    [HideInInspector] public bool Spe1Tronc = false;
    [HideInInspector] public bool Spe2Tronc = false;

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
        player = GameObject.Find("Player");
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
                player.GetComponent<PlayerAttacks>().shotgunDamage += 2;
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("ProjectileNumber");
                player.GetComponent<PlayerAttacks>().shotgunProjectileNumber += 1;
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceShotGun");
                player.GetComponent<PlayerAttacks>().shotgunRate += 1.2f;
            }
        }

        // Barre 2
        if(BarName == "LevelBar2")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageMine");
                player.GetComponent<PlayerAttacks>().mineDamage += 2;
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusMine");
                player.GetComponent<PlayerAttacks>().mineRadius += 2;
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceMine");
                player.GetComponent<PlayerAttacks>().mineRate += 2;
            }
        }
        // Barre 3
        if(BarName == "LevelBar3")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("Missile Bonus");
               player.GetComponent<PlayerAttacks>().rocketNumber += 1;
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("RadiusMissile");
      //          player.GetComponent<PlayerAttacks>().rocketNumber += 2;
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("CadenceMissile");
                player.GetComponent<PlayerAttacks>().rocketRate += 2;
            }
        }
        // Barre 4
        if(BarName == "LevelBar4")
        {
            if(ButtonName == "Boost1")
            {
                Debug.Log("DamageOrbital");
                player.GetComponent<PlayerAttacks>().shieldDamage += 2;
            }
            if(ButtonName == "Boost2")
            {
                Debug.Log("SizeOrbital");
                player.GetComponent<PlayerAttacks>().shieldSize += 2;
            }
            if(ButtonName == "Boost3")
            {
                Debug.Log("VitesseRotaOrbital");
                player.GetComponent<PlayerAttacks>().shieldSpeed += 2;
            }
        }

        // Spe ShotGun
        if(BarName == "LevelBar1")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1ShotGun");
                Spe1ShotGun = true;
                player.GetComponent<PlayerAttacks>().shotgunIsBurning = true;
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2ShotGun");
                Spe2ShotGun = true;
                player.GetComponent<PlayerAttacks>().shotgunIsPiercing = true;
            }
        }
        // Spe Mine
        if(BarName == "LevelBar2")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Mine");
                Spe1Mine = true;
                player.GetComponent<PlayerAttacks>().mineIsShrapnel = true;
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Mine");
                Spe2Mine = true;
                player.GetComponent<PlayerAttacks>().mineIsIce = true;
            }
        }
        // Spe Missile
        if(BarName == "LevelBar3")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Missile");
                Spe1Missile = true;
                player.GetComponent<PlayerAttacks>().rocketIsResidual = true;
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Missile");
                Spe2Missile = true;
                player.GetComponent<PlayerAttacks>().rocketIsDoubleBounce = true;
            }
        }
        // Spe Orbital
        if(BarName == "LevelBar4")
        {
            if(ButtonName == "Spe1")
            {
                Debug.Log("Spe1Orbital");
                Spe1Orbital = true;
                player.GetComponent<PlayerAttacks>().shieldIsDouble = true;
            }
            if(ButtonName == "Spe2")
            {
                Debug.Log("Spe2Orbital");
                Spe2Orbital = true;
                player.GetComponent<PlayerAttacks>().shieldIsPewPew = true;
            }
        }
    }
}
