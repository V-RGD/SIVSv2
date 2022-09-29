using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class XP_Collect : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private GameManager gameManager;

    public int xpType;

    private float playerDist;

    private bool canAttract;

    private GameObject GreenBar;
    private GameObject YellowBar;
    private GameObject OrangeBar;
    private GameObject RedBar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        GreenBar = GameObject.Find("LevelBar1");
        YellowBar = GameObject.Find("LevelBar2");
        OrangeBar = GameObject.Find("LevelBar3");
        RedBar = GameObject.Find("LevelBar4");
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = (player.transform.position - transform.position).magnitude;

        if (playerDist <= 5  || canAttract)
        {
            canAttract = true;
            rb.AddForce((player.transform.position - transform.position) * 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (xpType == 0)
            {
                gameManager.greenXP++;
                GreenBar.GetComponent<LevelBar>().BoostLevel(20);
            }
            if (xpType == 1)
            {
                gameManager.yellowXP++;
                YellowBar.GetComponent<LevelBar>().BoostLevel(20);
            }
            if (xpType == 2)
            {
                gameManager.orangeXP++;
                OrangeBar.GetComponent<LevelBar>().BoostLevel(20);
            }
            if (xpType == 3)
            {
                gameManager.redXP++;
                RedBar.GetComponent<LevelBar>().BoostLevel(20);
            }
            Destroy(gameObject);
        }
    }
}
