using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    //--------------shotgun ------------------envoie X balles en Y arc de cercle toutes les Z secondes
    public float shotgunRate;
    public float shotgunSpread; //reliés
    public float shotgunProjectileNumber = 2;
    public float shotgunRange;
    //modules
    public bool shotgunIsExplosive;
    public bool shotgunIsPiercing;
    public bool shotgunIsDoubleShot;
    //------------missile guidé ------------- Instancie un missile qui ne touche pas le joueur mais se dirige vers l'ennemi le plus proche
    public float rocketRate;
    public float rocketRadius;
    //modules
    public bool rocketIsResidual;
    public bool rocketIsBonusRocket;
    public bool rocketIsDoubleBounce;
    //-----------------mines ----------------- instancie une mine qui explose toutes les X secondes
    public float mineRate;
    public float mineRadius;
    //modules
    public bool rocketIsShrapnel;
    //-----------------shield ------------------ orbite a une certaine distance du joueur 
    public float shieldRate;
    public float shieldRange;
    public float shieldSpeed;//reliés
    
    //tweak values to balance 
    public float shotgunProjectileDamage;
    public float rocketDamage;
    public float mineDamage;
    public float shieldDamage;

    //prefabs instanciated when attacks
    public GameObject shotgunProjo;
    public GameObject rocketProjo;
    public GameObject mineProjo;
    public GameObject shieldProjo;

    //requirements for activations
    public bool isShogunActive;
    public bool isRocketActive;
    public bool isMinesActive;
    public bool isShieldActive;

    public float shotgunSpeed = 10;
    public float rocketSpeed = 100;

    public Vector2 attackDir;
    public GameObject player;
    public GameObject target;

    private Transform[] enemyPoses;
    private Spawner spawner;
    
    public float shotgunTimer;
    public float rocketTimer;
    public float mineTimer;
    
    public float shotgunCooldown = 2;
    public float rocketCooldown = 4;
    public float mineCooldown = 3;
    

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //FindClosestEnemy();
        attackDir = (target.transform.position - transform.position).normalized;

        if (shotgunTimer <= 0)
        {
            shotgunTimer = shotgunCooldown;
            ShotgunShot();
        }
        if (rocketTimer <= 0 && isRocketActive)
        {
            rocketTimer = rocketCooldown;
            RocketShot();   
        }

        if (mineTimer <= 0 && isMinesActive)
        {
            mineTimer = mineCooldown;
            MineLaunch();
        }

        if (isShieldActive)
        {
            //shieldProjo.SetActive(true);
            //rotates around players
            ShieldRotation();
        }
        
        shotgunTimer -= Time.deltaTime;
        rocketTimer -= Time.deltaTime;
        rocketTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        
    }

    void ShotgunShot()
    {
        //instanciate X projo separated by Y angle, does Z damage, dissapears after W range
        for (int i = 0; i < shotgunProjectileNumber; i++)
        {
            GameObject projo = Instantiate(shotgunProjo, transform.position, Quaternion.identity);
            projo.GetComponent<Rigidbody2D>().AddForce(attackDir * shotgunSpeed);
        }
    }

    void RocketShot()
    {
        GameObject rocket = Instantiate(rocketProjo, transform.position, Quaternion.identity);
        rocket.GetComponent<Rigidbody2D>().AddForce(attackDir * rocketSpeed);
    }

    void MineLaunch()
    {
        Instantiate(mineProjo, transform.position, Quaternion.identity);
    }

    void ShieldRotation()
    {
        
    }

    void FindClosestEnemy()
    {
        //spawner adds each enemy to the array enemies
        enemyPoses = spawner.enemyPoses.ToArray();
        //takes the closest one from the player
        target = GetClosestEnemy(enemyPoses).gameObject;
    }
    
    Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }
}
