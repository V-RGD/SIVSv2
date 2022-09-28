using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private GameObject Boost1;
    private GameObject Boost2;
    private GameObject Boost3;
    
    private float currentlevel;

    // Panel Selection amélioration
    public GameObject UpgradePanel;
    public GameObject SpeUpgradePanel;
    

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");

  //      UpgradePanel = GameObject.Find("SelectUpgradePanel");
        UpgradePanel.SetActive(false);
        SpeUpgradePanel.SetActive(false);
    }

    void Update()
    {
        currentlevel = gameObject.GetComponent<Slider>().value;
    }

    public void SetMaxLevel(float level)
    {
        slider.maxValue = level;
        slider.value = level;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetLevel(float level)
    {
        slider.value = level;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

        public void BoostLevel(float boost)
    {
       currentlevel += boost;
       SetLevel(currentlevel);

       if(currentlevel + 10 > 100)
       {
        if(gameObject.name == "LevelBar1")
        {
            NumberOfUpdates.instance.TiersShotGun += 1;
            BoostersParents.instance.TheBar = "LevelBar1";
          if(NumberOfUpdates.instance.TiersShotGun == 4)
          {
            SpeBoostersParents.instance.TheBar = "LevelBar1";

            SpeUpgradePanel.SetActive(true);
            SpeBoostersParents.instance.NameUpdate();
            SpeBoostersParents.instance.Transition();
          }
        else
        {
            UpgradePanel.SetActive(true);
            BoostersParents.instance.NameUpdate();
            BoostersParents.instance.Transition();
        }
        }
        if(gameObject.name == "LevelBar2")
        {
            NumberOfUpdates.instance.TiersMine += 1;
            BoostersParents.instance.TheBar = "LevelBar2";
          if(NumberOfUpdates.instance.TiersMine == 4)
          {
            SpeBoostersParents.instance.TheBar = "LevelBar2";
            SpeUpgradePanel.SetActive(true);
            SpeBoostersParents.instance.NameUpdate();
            SpeBoostersParents.instance.Transition();
          }
          else
        {
            UpgradePanel.SetActive(true);
            BoostersParents.instance.NameUpdate();
            BoostersParents.instance.Transition();
        }
        }
        if(gameObject.name == "LevelBar3")
        {
            NumberOfUpdates.instance.TiersMissile += 1;
            BoostersParents.instance.TheBar = "LevelBar3";
          if(NumberOfUpdates.instance.TiersMissile == 4)
          {
            SpeBoostersParents.instance.TheBar = "LevelBar3";
            SpeUpgradePanel.SetActive(true);
            SpeBoostersParents.instance.NameUpdate();
            SpeBoostersParents.instance.Transition();
          }
          else
        {
            UpgradePanel.SetActive(true);
            BoostersParents.instance.NameUpdate();
            BoostersParents.instance.Transition();
        }
        }
        if(gameObject.name == "LevelBar4")
        {
            NumberOfUpdates.instance.TiersOrbital += 1;
            BoostersParents.instance.TheBar = "LevelBar4";
          if(NumberOfUpdates.instance.TiersOrbital == 4)
          {
            SpeBoostersParents.instance.TheBar = "LevelBar4";
            SpeUpgradePanel.SetActive(true);
            SpeBoostersParents.instance.NameUpdate();
            SpeBoostersParents.instance.Transition();
          }
          else
        {
            UpgradePanel.SetActive(true);
            BoostersParents.instance.NameUpdate();
            BoostersParents.instance.Transition();
        }
        }
        if(gameObject.name == "LevelBar5")
        {
            NumberOfUpdates.instance.TiersTronc += 1;
            BoostersParents.instance.TheBar = "LevelBar5";
          if(NumberOfUpdates.instance.TiersTronc == 4)
          {
            SpeBoostersParents.instance.TheBar = "LevelBar5";
            SpeUpgradePanel.SetActive(true);
            SpeBoostersParents.instance.NameUpdate();
            SpeBoostersParents.instance.Transition();
          }
          else
        {
            UpgradePanel.SetActive(true);
            BoostersParents.instance.NameUpdate();
            BoostersParents.instance.Transition();
        }
        }
        SetLevel(0);
        Yazid_Script.instance.isPaused = true;
       }
    }

    public  void SelectUpgrade()
        {
            UpgradePanel.SetActive(false);
            SpeUpgradePanel.SetActive(false);
            Yazid_Script.instance.isPaused = false;
        } 
}