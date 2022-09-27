using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
  //  public Color newColor;

    public UpgradeWeapons upgradeScriptableObject1;
    public UpgradeWeapons upgradeScriptableObject2;
    public UpgradeWeapons upgradeScriptableObject3;

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
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