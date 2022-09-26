using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Vector3 vPlayer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vPlayer = player.transform.position;
        StartCoroutine(spawner());
    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemy, new Vector3(Random.Range(vPlayer.x -5,vPlayer.x +5), Random.Range(vPlayer.y -5,vPlayer.y +5), 0), Quaternion.identity);
    }
}
