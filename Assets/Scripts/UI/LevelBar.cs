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

    // ScripatbleObject
    public UpgradeWeapons Weapons;
    

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");

  //      UpgradePanel = GameObject.Find("SelectUpgradePanel");
        UpgradePanel.SetActive(false);
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
            BoostersParents.instance.TheBar = "LevelBar1";
        }
        if(gameObject.name == "LevelBar2")
        {
            BoostersParents.instance.TheBar = "LevelBar2";
        }
        if(gameObject.name == "LevelBar3")
        {
            BoostersParents.instance.TheBar = "LevelBar3";
        }
        if(gameObject.name == "LevelBar4")
        {
            BoostersParents.instance.TheBar = "LevelBar4";
        }
        if(gameObject.name == "LevelBar5")
        {
            BoostersParents.instance.TheBar = "LevelBar5";
        }
         BoostersParents.instance.NameUpdate();
         BoostersParents.instance.Transition();
        SetLevel(0);
        UpgradePanel.SetActive(true);
       }
    }

    public  void SelectUpgrade()
        {
            UpgradePanel.SetActive(false);
        } 
}