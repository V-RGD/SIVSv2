
using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public Texture2D cursorAim;
    
    public float maxSpeed;
    private float speedFactor = 1;
    public Vector2 movementDir;

    
    //public InputAction spell;

    [Header("Movement")] 
    public float acceleration;
    public bool canMove;
    public float frictionAmount;

    [Header("Components")] [HideInInspector]
    private Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    private Animator animator;
    private GameManager gameManager;

    [Header("Extra Values")] [HideInInspector]

    [Header("Attacks")] public float jabLenght;
    public float smashLenght;
    //time 
    public float smashWarmup;
    public float smashDamage;
    public float jabDamage;
    private float jabReach;
    public float comboCooldown;
    //max time allowed to combo
    
    private float comboTimer;
    private int comboCounter;
    
    public bool isAttacking;

    public GameObject SmashHitBox;
    public GameObject JabHitBox;

    private float attackMultiplier = 1;

    public float invincibleCounter;
    public float invincibleTime;
    private bool isInvincible;

    public Vector2 inputDir;

    //used to change direction accordingly to sprite direction
    public int dirCoef;

    [Header("Movement")] 
    public Animator playerAnimator;

    // Sound Effects
    public AudioClip TakeDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        playerAnimator.SetBool("isRunning", false);
        playerAnimator.SetBool("isHit", false);
        canMove = true;
        isAttacking = false;
        Cursor.SetCursor(cursorAim, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        Flip(rb.velocity.x);
        
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (canMove)
        {
            JostickDir();
        }
        Timer();
    }

    #region Basic Movement

    void MovePlayer()
    {
        if (movementDir!= Vector2.zero && speedFactor != 0)
        {
            playerAnimator.SetBool("isRunning", true);
            rb.AddForce(new Vector3(movementDir.x * acceleration, movementDir.y * acceleration));
            
            //cap x speed
            if(rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.y);
            }
            if(rb.velocity.x < -maxSpeed)
            {
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.y);
            }
            
            //cap y speed
            if(rb.velocity.y > maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x,  maxSpeed);
            }
            if(rb.velocity.y < -maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x,-maxSpeed);
            }
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            rb.velocity = Vector2.zero;
        }
        if (movementDir.x == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (movementDir.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    #endregion
    
        
    #region Flip

        void Flip(float velocity)
        {
            //Flips the sprite when turning around
            if (movementDir.x > 0.1f)
            {
                spriteRenderer.flipX = false;
            }

            else if (movementDir.x < -0.1f)
            {
                spriteRenderer.flipX = true;
            }

            if (!spriteRenderer.flipX)
            {
                dirCoef = 1;
            }
            else
            {
                dirCoef = -1;
            }
        }

        #endregion
        

        #region Timer
        void Timer()
        {
            comboTimer -= Time.deltaTime;
            invincibleCounter -= Time.deltaTime;

            if (comboTimer <= 0)
            {
                comboCounter = 0;
            }

            if (invincibleCounter > 0)
            {
                isInvincible = true;
            }
            else
            {
                isInvincible = false;
            }
        }
        #endregion
        
        void JostickDir()
        {
            //le perso bouge
            inputDir.x = Input.GetAxisRaw("Horizontal");
            inputDir.y = Input.GetAxisRaw("Vertical");
            movementDir = inputDir;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                AudioManager.instance.PlayClipAt(TakeDamage, transform.position);
                //playerAnimator.SetBool("isHit", true);
                gameManager.health -= col.GetComponent<Enemy>().damage;
                Debug.Log("lost damage");
                //GetComponent<Animator>().SetTrigger("Hurt");
                GameObject.Find("Shake").GetComponent<CameraShake>().shakeCamera.Invoke();
            }
            
        }
}



    





