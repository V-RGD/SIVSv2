using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int money;
    public float health;
    public int maxHealth = 100;
    public GameObject[] items;
    public Slider healthBar;

    public float greenXP;
    public float yellowXP;
    public float orangeXP;
    public float redXP;


    private void Awake()
    {
        player = GameObject.Find("Player");
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.value = health / maxHealth;
    }

    void Start()
    {
        health = maxHealth;
    }
}
