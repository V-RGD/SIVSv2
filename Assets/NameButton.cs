using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameButton : MonoBehaviour
{
    private string nameButton;
    // Start is called before the first frame update
    void Start()
    {
        nameButton = gameObject.transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        NumberOfUpdates.instance.ButtonName = nameButton;
    }
}
