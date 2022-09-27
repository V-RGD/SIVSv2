using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Panel Selection amélioration
    private GameObject UpgradePanel;

    // Pause
    private GameObject PauseMenu;
    private bool isPaused;

    // Settings
    private GameObject PanelSettings;

    // Start is called before the first frame update
    void Start()
    {
        UpgradePanel = GameObject.Find("SelectUpgradePanel");
        UpgradePanel.SetActive(false);
        TheScore = GameObject.Find("Score");
        currentHealth = health.GetComponent<Slider>().value;
        currentlevel = level.GetComponent<Slider>().value;
        PauseMenu = GameObject.Find("PauseMenuPanel");
        PauseMenu.SetActive(false);
        PanelSettings = GameObject.Find("SettingsPanel");
        PanelSettings.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.A))
        {
            UpgradePanel.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            PauseMenu.SetActive(true);
        }
        // Pause Menu
        if(isPaused)
        {
            Time.timeScale = 0;
        }
    }

        public  void SelectUpgrade()
        {
            UpgradePanel.SetActive(false);
        }

        // Pause Menu

        // Resume Button
        public void Resume()
    {
        PauseMenu.SetActive(false); 
        Time.timeScale = 1;
        isPaused = false;
    }

         // Restart Button
    public void Restart()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("Yazid");
    }

    // Main Menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PauseMenu.SetActive(false);
    }

    // Quit Button
    public void Quit()
    {
        Application.Quit();
    }

    // Start Button
        public void StartGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("Yazid");
    }

        public void OpenSettings()
    {
        PanelSettings.SetActive(true);
    }
        public void CloseSettings()
    {
        PanelSettings.SetActive(false);
    }
}
