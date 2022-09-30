using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Yazid_Script : MonoBehaviour
{

    public static Yazid_Script instance;
     private void Awake()
    {
            if (instance != null)
            {
              return;
            }
            instance = this;
    }

    // Experience
    public LevelBar level1;
    public LevelBar level2;
    public LevelBar level3;
    public LevelBar level4;

    // Score
    private GameObject TheScore;

    // Pause
    private GameObject PauseMenu;
    public bool isPaused;

    // Settings
    private GameObject PanelSettings;

    // Sound
    public AudioClip sound;

    // The Animator
    public Animator PauseAnimator;
 //   public Animator DeathAnimator;

    // Mort
    private GameObject PanelDeath;
    private GameObject TheGameManager;

    // Start is called before the first frame update
    void Start()
    {
        TheScore = GameObject.Find("Score");
        PauseMenu = GameObject.Find("PauseMenuPanel");
        PauseMenu.SetActive(false);
        PanelSettings = GameObject.Find("SettingsPanel");
        PanelSettings.SetActive(false);
        BoostersParents.instance.ResetLevel();
        PauseAnimator = PauseMenu.GetComponent<Animator>();
        PanelDeath = GameObject.Find("PanelDeath");
        TheGameManager = GameObject.Find("GameManager");
        PanelDeath.SetActive(false);
     //   DeathAnimator = PanelDeath.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mort
        if(TheGameManager.GetComponent<GameManager>().health <= 0)
        {
            Time.timeScale = 0;
            PanelDeath.SetActive(true);
        }
        // Sound
         if(Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
        }


        // LevelBar
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            level1.GetComponent<LevelBar>().BoostLevel(50);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            level2.GetComponent<LevelBar>().BoostLevel(50);
        }
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            level3.GetComponent<LevelBar>().BoostLevel(50);
        }
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            level4.GetComponent<LevelBar>().BoostLevel(50);
        }

        // Score
        if(Input.GetKeyDown(KeyCode.M))
        {
            TheScore.GetComponent<Score>().currentScore += 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            PauseMenu.SetActive(true);
            PauseAnimator.SetBool("isOpening",true);
            PauseAnimator.SetBool("isClosing",false);
        }
        // Pause Menu
        if(isPaused)
        {
            Time.timeScale = 0;
        }
    }

        // Pause Menu

        // Resume Button
        public void Resume()
    {
        PauseMenu.SetActive(false); 
        Time.timeScale = 1;
        isPaused = false;
        PauseAnimator.SetBool("isClosing",true);
        PauseAnimator.SetBool("isOpening",false);
    }

         // Restart Button
    public void Restart()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        TheGameManager.GetComponent<GameManager>().health = 100;
        PanelDeath.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("SceneFinale");
        BoostersParents.instance.ResetLevel();
    }

    // Main Menu
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        PauseMenu.SetActive(false);
        PanelDeath.SetActive(false);
        BoostersParents.instance.ResetLevel();
    }

    // Quit Button
    public void Quit()
    {
        Application.Quit();
        BoostersParents.instance.ResetLevel();
    }

    // Start Button
        public void StartGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("SceneFinale");
        BoostersParents.instance.ResetLevel();
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
