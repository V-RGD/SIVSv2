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
    public float maxLevel;

    // Panel Selection amélioration
    public GameObject UpgradePanel;
    public GameObject SpeUpgradePanel;
    

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");
        maxLevel = gameObject.GetComponent<Slider>().maxValue;

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

       if(currentlevel + 10 > maxLevel)
       {
        if(gameObject.name == "LevelBar1")
        {
            gameObject.GetComponent<Slider>().maxValue += 10;
            maxLevel = gameObject.GetComponent<Slider>().maxValue;
            NumberOfUpdates.instance.TiersShotGun += 1;
            BoostersParents.instance.TheBar = "LevelBar1";
          if(NumberOfUpdates.instance.TiersShotGun == 4 || NumberOfUpdates.instance.TiersShotGun == 9)
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
            gameObject.GetComponent<Slider>().maxValue += 20;
            maxLevel = gameObject.GetComponent<Slider>().maxValue;
            NumberOfUpdates.instance.TiersMine += 1;
            BoostersParents.instance.TheBar = "LevelBar2";
          if(NumberOfUpdates.instance.TiersMine == 4 || NumberOfUpdates.instance.TiersMine == 9)
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
            gameObject.GetComponent<Slider>().maxValue += 30;
            maxLevel = gameObject.GetComponent<Slider>().maxValue;
            NumberOfUpdates.instance.TiersMissile += 1;
            BoostersParents.instance.TheBar = "LevelBar3";
          if(NumberOfUpdates.instance.TiersMissile == 4 || NumberOfUpdates.instance.TiersMissile == 9)
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
            gameObject.GetComponent<Slider>().maxValue += 40;
            maxLevel = gameObject.GetComponent<Slider>().maxValue;
            NumberOfUpdates.instance.TiersOrbital += 1;
            BoostersParents.instance.TheBar = "LevelBar4";
          if(NumberOfUpdates.instance.TiersOrbital == 4 || NumberOfUpdates.instance.TiersOrbital == 9)
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
            gameObject.GetComponent<Slider>().maxValue += 50;
            maxLevel = gameObject.GetComponent<Slider>().maxValue;
            NumberOfUpdates.instance.TiersTronc += 1;
            BoostersParents.instance.TheBar = "LevelBar5";
          if(NumberOfUpdates.instance.TiersTronc == 4 || NumberOfUpdates.instance.TiersTronc == 9)
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