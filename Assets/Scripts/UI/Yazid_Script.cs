using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yazid_Script : MonoBehaviour
{

    // Health
    public HealthBar health;
    public float currentHealth;

    // Experience
    public LevelBar level;
    public float currentlevel;

    // Score
    private GameObject TheScore;
    // Start is called before the first frame update
    void Start()
    {
        TheScore = GameObject.Find("Score");
        currentHealth = health.GetComponent<Slider>().value;
        currentlevel = level.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        // Health
        currentHealth = health.GetComponent<Slider>().value;

        if(Input.GetKeyDown(KeyCode.E))
        {
            currentHealth -= 10;
            health.GetComponent<HealthBar>().SetHealth(currentHealth);
        }

        // Experience
        currentlevel = level.GetComponent<Slider>().value;

        if(Input.GetKeyDown(KeyCode.L))
        {
            currentlevel += 10;
            level.GetComponent<LevelBar>().SetLevel(currentlevel);
        }

        // Score
        if(Input.GetKeyDown(KeyCode.M))
        {
            TheScore.GetComponent<Score>().currentScore += 1;
        }
    }
}
