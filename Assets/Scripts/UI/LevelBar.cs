using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    // SoundEffects
    public AudioClip GainXP;
    public AudioClip UpgradeSelection;
    public AudioClip OpenUpgrade;

    private GameObject player;

    void Start()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Boost1 = GameObject.Find("Boost1");
        Boost2 = GameObject.Find("Boost2");
        Boost3 = GameObject.Find("Boost3");
        maxLevel = gameObject.GetComponent<Slider>().maxValue;
        player = GameObject.Find("Player");

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
       //AudioManager.instance.PlayClipAt(GainXP, transform.position);
       currentlevel += boost;
       SetLevel(currentlevel);

       if(currentlevel + 10 > maxLevel)
       {
        AudioManager.instance.PlayClipAt(OpenUpgrade, transform.position);
        if(gameObject.name == "LevelBar1")
        {
            gameObject.GetComponent<Slider>().maxValue += 10;  // Augementation du Maximum de la barre
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
            player.GetComponent<PlayerAttacks>().isMinesActive = true;
            gameObject.GetComponent<Slider>().maxValue += 20; // Augementation du Maximum de la barre
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
            player.GetComponent<PlayerAttacks>().isRocketActive = true;
            gameObject.GetComponent<Slider>().maxValue += 30; // Augementation du Maximum de la barre
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
            player.GetComponent<PlayerAttacks>().isShieldActive = true;
            gameObject.GetComponent<Slider>().maxValue += 40; // Augementation du Maximum de la barre
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
        SetLevel(0);
        Yazid_Script.instance.isPaused = true;
       }
    }

    public  void SelectUpgrade()
        {
            AudioManager.instance.PlayClipAt(UpgradeSelection, transform.position);
            UpgradePanel.SetActive(false);
            SpeUpgradePanel.SetActive(false);
            Yazid_Script.instance.isPaused = false;
        } 
}