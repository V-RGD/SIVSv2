using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class XP_Collect : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private GameManager gameManager;

    public int xpType;

    private float playerDist;

    private bool canAttract;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
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
            }
            if (xpType == 1)
            {
                gameManager.yellowXP++;
            }
            if (xpType == 2)
            {
                gameManager.orangeXP++;
            }
            if (xpType == 3)
            {
                gameManager.redXP++;
            }
            Destroy(gameObject);
        }
    }
}
