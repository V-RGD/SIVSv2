using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    public Sprite[] sprites;
    public float healthRestored = 10;
    private GameManager gm;
    void Start()
    {
        int randSprite = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[randSprite];
        if (randSprite == 0)
        {
            healthRestored = 1000;
        }

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.health += healthRestored;
            Destroy(gameObject);
        }
    }
}
