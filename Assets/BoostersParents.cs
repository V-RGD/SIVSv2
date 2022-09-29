using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostersParents : MonoBehaviour
{

    public UpgradeWeapons ShotGun;
    public UpgradeWeapons Mine;
    public UpgradeWeapons Missile;
    public UpgradeWeapons Orbital;
    public UpgradeWeapons Tronc;

    public string TheBar;

    public static BoostersParents instance;
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

    public void NameUpdate()
    {
        gameObject.transform.GetChild(0).GetComponent<Boosters>().BarName = TheBar;
        gameObject.transform.GetChild(1).GetComponent<Boosters>().BarName = TheBar;
        gameObject.transform.GetChild(2).GetComponent<Boosters>().BarName = TheBar;
    }

    public void Transition()
    {
     /*   if(gameObject.transform.parent.name == "SelectSpePanel")
        {
        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshBar();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshBar(); 

        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshSelectPanel();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshSelectPanel();     
        } */


        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshBar();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshBar();
        gameObject.transform.GetChild(2).GetComponent<Boosters>().RefreshBar();

        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshSelectPanel();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshSelectPanel();
        gameObject.transform.GetChild(2).GetComponent<Boosters>().RefreshSelectPanel();

    }

    public void ResetLevel()
    {
        // ShotGun Reset
        ShotGun.TheStats[0].niveau = 0;
        ShotGun.TheStats[1].niveau = 0;
        ShotGun.TheStats[2].niveau = 0;
        // Mine Reset
        Mine.TheStats[0].niveau = 0;
        Mine.TheStats[1].niveau = 0;
        Mine.TheStats[2].niveau = 0;
        // Missile Reset
        Missile.TheStats[0].niveau = 0;
        Missile.TheStats[1].niveau = 0;
        Missile.TheStats[2].niveau = 0;
        // Orbital Reset
        Orbital.TheStats[0].niveau = 0;
        Orbital.TheStats[1].niveau = 0;
        Orbital.TheStats[2].niveau = 0;
        // Tronc Reset
        Tronc.TheStats[0].niveau = 0;
        Tronc.TheStats[1].niveau = 0;
        Tronc.TheStats[2].niveau = 0;
    }
}
