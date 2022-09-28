using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
  //  public Color newColor;

/*    public UpgradeWeapons upgradeScriptableObject1;
    public UpgradeWeapons upgradeScriptableObject2;
    public UpgradeWeapons upgradeScriptableObject3; */

    private GameObject Boost1;
    private GameObject Boost2;
    private GameObject Boost3;

    /* Upgrades
    public string name;
    public string description;
    public string level; */

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");
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
    //    newColor = new Color(fill.color.r, fill.color.g, fill.color.b, 0f);
    }
}