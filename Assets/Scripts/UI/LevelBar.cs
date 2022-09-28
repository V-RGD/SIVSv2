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

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");
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
    }
}