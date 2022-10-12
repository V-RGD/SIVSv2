using UnityEngine;
using UnityEngine.UI;

public class Chronometre : MonoBehaviour
{
    public Text Chrono;
 //   public Text ChronoDix;
    public float timer = 0;
    public bool isTiming;
    private GameObject VictoirePanel;
/*    public float seconde;
    public float dix; */
    // Start is called before the first frame update

    public static Chronometre instance;

    private void Awake()
    {
            if (instance != null)
            {
              Destroy(gameObject);
              return;
            }
            instance = this;
    }

    void Start()
    {
        timer = PlayerPrefs.GetFloat("Timer");
        VictoirePanel = GameObject.Find("VictoirePanel");
        VictoirePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Chrono.text == "20:00")
        {
            VictoirePanel.SetActive(true);
        }
        else if (Chrono.text == "20:08")
        {
            VictoirePanel.SetActive(false);
        }
//      seconde = Mathf.Floor (timer % 60);
    //  dix = timer - seconde;
    if(isTiming)
    {
      timer += Time.deltaTime;
    }
  //    Chrono.text = "" + timer;  
      Chrono.text = string.Format ("{0:00}:{1:00}", Mathf.Floor (timer / 60), timer % 60);
   //   ChronoDix.text = "" + dix;
    }

    public void SaveTimer()
    {
        PlayerPrefs.SetFloat("Timer", timer);
    }
    public void LoadSaveTimer()
    {
        timer = PlayerPrefs.GetFloat("Timer");
    }
}
