using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeBoostersParents : MonoBehaviour
{

    public Specialization SpeShotGun;
    public Specialization SpeMine;
    public Specialization SpeMissile;
    public Specialization SpeOrbital;
    public Specialization SpeTronc;

    public string TheBar;

    public static SpeBoostersParents instance;
     private void Awake()
    {
            if (instance != null)
            {
              return;
            }
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NameUpdate()
    {
        gameObject.transform.GetChild(0).GetComponent<Boosters>().BarName = TheBar;
        gameObject.transform.GetChild(1).GetComponent<Boosters>().BarName = TheBar;
    }

    public void Transition()
    {
        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshBar();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshBar();

        gameObject.transform.GetChild(0).GetComponent<Boosters>().RefreshSelectPanel();
        gameObject.transform.GetChild(1).GetComponent<Boosters>().RefreshSelectPanel();
    }

    public void ResetLevel()
    {
        Debug.Log("Spe");
    }
}
