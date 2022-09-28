using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfUpdates : MonoBehaviour
{
    // Number of Tiers
    public int TiersShotGun;
    public int TiersMine;
    public int TiersMissile;
    public int TiersOrbital;
    public int TiersTronc;

    public static NumberOfUpdates instance;
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
}
