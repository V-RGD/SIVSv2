using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeBoostersParents : MonoBehaviour
{

    public Specialization SpeShotGun;
    public Specialization SpeMine;
    public Specialization SpeMissile;
    public Specialization SpeOrbital;
    public Specialization SpeTronc;

    public string TheBar;

    public Button Spe1;
    public Button Spe2;

    public static SpeBoostersParents instance;
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
        if(TheBar == "LevelBar1")
        {
           if(NumberOfUpdates.instance.Spe1ShotGun)
         {
            Spe1.interactable = false;
         }
           if(NumberOfUpdates.instance.Spe2ShotGun)
         {
            Spe2.interactable = false;
         }
        }
         if(TheBar == "LevelBar2")
        {
           if(NumberOfUpdates.instance.Spe1Mine)
         {
            Spe1.interactable = false;
         }
           if(NumberOfUpdates.instance.Spe2Mine)
         {
            Spe2.interactable = false;
         }
        }
          if(TheBar == "LevelBar3")
        {
           if(NumberOfUpdates.instance.Spe1Missile)
         {
            Spe1.interactable = false;
         }
           if(NumberOfUpdates.instance.Spe2Missile)
         {
            Spe2.interactable = false;
         }
        }
           if(TheBar == "LevelBar4")
        {
           if(NumberOfUpdates.instance.Spe1Orbital)
         {
            Spe1.interactable = false;
         }
           if(NumberOfUpdates.instance.Spe2Orbital)
         {
            Spe2.interactable = false;
         }
        }
            if(TheBar == "LevelBar5")
        {
           if(NumberOfUpdates.instance.Spe1Tronc)
         {
            Spe1.interactable = false;
         }
           if(NumberOfUpdates.instance.Spe2Tronc)
         {
            Spe2.interactable = false;
         }
        }
          gameObject.transform.GetChild(0).GetComponent<Boosters>().BarName = TheBar;
          gameObject.transform.GetChild(1).GetComponent<Boosters>().BarName = TheBar;
    }

    public void Transition()
    {
        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshBar();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshBar();

        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshSelectPanel();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshSelectPanel();
    }

    public void ResetButton()
    {
        SpeBoostersParents.instance.Spe1.interactable = true;
        SpeBoostersParents.instance.Spe2.interactable = true;
    }

    public void ResetLevel()
    {
        Debug.Log("Spe");
    }
}
