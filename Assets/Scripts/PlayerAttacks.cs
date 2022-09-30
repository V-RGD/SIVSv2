using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    //--------------shotgun ------------------envoie X balles en Y arc de cercle toutes les Z secondes
    public float shotgunRate = 1;
    public float shotgunProjectileNumber = 15;
    public float shotgunDamage;
    //modules
    public bool shotgunIsBurning;
    public bool shotgunIsPiercing;
    //public bool shotgunIsDoubleShot;
    //------------missile guidé ------------- Instancie un missile qui ne touche pas le joueur mais se dirige vers l'ennemi le plus proche
    public float rocketRate = 1;
    public float rocketNumber;
    //modules
    public bool rocketIsResidual;
    public bool rocketIsDoubleBounce;
    //-----------------mines ----------------- instancie une mine qui explose toutes les X secondes
    public float mineRate = 1;
    public float mineRadius;
    public float mineDamage;
    //modules
    public bool mineIsShrapnel;
    public bool mineIsIce;
    //-----------------shield ------------------ orbite a une certaine distance du joueur 
    public float shieldDamage;
    public float shieldSize;
    public float shieldSpeed = 1;//reliés
    //modules
    public bool shieldIsDouble;
    public bool shieldIsPewPew;
    
    //tweak values to balance 
    public float rocketDamage;
    
    public float shotgunSpread = 4; //reliés

    //prefabs instanciated when attacks
    public GameObject shotgunProjo;
    public GameObject rocketProjo;
    public GameObject mineProjo;
    public GameObject shieldProjo;

    //requirements for activations
    public bool isShogunActive = true;
    public bool isRocketActive;
    public bool isMinesActive;
    public bool isShieldActive;

    public float shotgunSpeed = 100;
    private float rocketSpeed = 8;

    public Vector2 attackDir;
    public GameObject target;
    
    public Transform[] enemyPoses;
    private Spawner spawner;
    
    //for timer purposes only
    private float shotgunTimer;
    private float rocketTimer;
    private float mineTimer;
    private float shieldPewPewTimer;
    private float shieldRotation;
    
    //cooldown for all weapons
    public float shotgunCooldown = 2;
    public float rocketCooldown = 4;
    public float mineCooldown = 3;
    public float shieldPewPewCooldown = 3;

    public bool isShotGunManual = true;
    private Vector2 mousePos;
    private Vector2 mouseDir;
    public Camera cam;

    private GameObject shield1;
    private GameObject shield2;
    private GameObject shield3;

    private List<GameObject> bulletsPooling;
    private List<GameObject> rocketsPooling;
    private List<GameObject> minesPooling;

    private void Awake()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        shield1 = shieldProjo.transform.GetChild(0).gameObject;
        shield2 = shieldProjo.transform.GetChild(1).gameObject;
        shield3 = shieldProjo.transform.GetChild(2).gameObject;
    }

    void Update()
    {
        mouseDir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        LookAtMouse();
        FindClosestEnemy();
        if (target != null)
        {
            attackDir = (target.transform.position - transform.position).normalized;
            
            if (shotgunTimer <= 0)
            {
                shotgunTimer = shotgunCooldown/shotgunRate;
                ShotgunShot();
            }
            if (rocketTimer <= 0 && isRocketActive)
            {
                rocketTimer = rocketCooldown/rocketRate;
                StartCoroutine(RocketShot());
            }

            if (mineTimer <= 0 && isMinesActive)
            {
                mineTimer = mineCooldown/mineRate;
                MineLaunch();
            }
        }

        if (isShieldActive)
        {
            shield1.SetActive(true);
            //rotates around players
            shieldRotation += Time.deltaTime * 360 * shieldSpeed;
            shieldProjo.transform.rotation = Quaternion.Euler(0, 0, shieldRotation);

            shield1.GetComponent<AttackDamage>().damage = shieldDamage;
            shield2.GetComponent<AttackDamage>().damage = shieldDamage;
            shield3.GetComponent<AttackDamage>().damage = shieldDamage;
            
            shield1.transform.localScale = new Vector3(shieldSize, shieldSize, shieldSize);
            shield2.transform.localScale = new Vector3(shieldSize, shieldSize, shieldSize);
            shield3.transform.localScale = new Vector3(shieldSize, shieldSize, shieldSize);
            

            if (shieldRotation > 360)
            {
                shieldRotation = 0;
            }

            if (shieldIsDouble)
            {
                shield2.SetActive(true);
                shield3.SetActive(true);
                
                shield3.gameObject.transform.rotation = Quaternion.Euler(0, 0, shieldRotation * 2.7f);
            }
            else
            {
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
            }
            shield1.transform.localRotation = Quaternion.Euler(0, 0, -shieldRotation);
            shield2.transform.localRotation = Quaternion.Euler(0, 0, -shieldRotation);
            shield3.transform.localRotation = Quaternion.Euler(0, 0, -shieldRotation);

            if (shieldIsPewPew && shieldPewPewTimer <= 0)
            {
                shieldPewPewTimer = shieldPewPewCooldown;
                StartCoroutine(ShieldBarrel());
            }
        }
        else
        {
            shield1.SetActive(false);
        }

        shotgunTimer -= Time.deltaTime;
        rocketTimer -= Time.deltaTime;
        mineTimer -= Time.deltaTime;
        shieldPewPewTimer -= Time.deltaTime;
    }
    void ShotgunShot()
    {
        
        #region oldSystem
        float rotationDiff = -shotgunSpread * shotgunProjectileNumber / 2;
        //instanciate X projo separated by Y angle, does Z damage, dissapears after W range
        for (int i = 0; i < shotgunProjectileNumber; i++)
        {
            Vector2 rotateDir;
            GameObject projo = Instantiate(shotgunProjo, transform.position, Quaternion.identity);
            if (!isShotGunManual)
            {
                rotateDir = Quaternion.Euler(0, 0, rotationDiff) * attackDir;
            }
            else
            {
                rotateDir = Quaternion.Euler(0, 0, rotationDiff) * mouseDir;
            }
            projo.GetComponent<Rigidbody2D>().AddForce(rotateDir * shotgunSpeed);
            projo.GetComponent<AttackDamage>().damage = shotgunDamage;
            if (shotgunIsPiercing)
            {
                //for piercing module
                projo.GetComponent<AttackDamage>().destroyedOnContact = false;
            }

            if (shotgunIsBurning)
            {
                projo.GetComponent<AttackDamage>().isFireAmmo = true;
            }
            rotationDiff += shotgunSpread;
        }
        #endregion
        /*
        #region newSystem
        
        float rotationDiff = -shotgunSpread * shotgunProjectileNumber / 2;
        //instanciate X projo separated by Y angle, does Z damage, dissapears after W range
        for (int i = 0; i < shotgunProjectileNumber; i++)
        {
            Vector2 rotateDir;
            GameObject projo;
            foreach (GameObject bullet in bulletsPooling)
            {
                if (bullet.gameObject.activeInHierarchy)
                {
                    break;
                }
                else
                {
                    projo = bullet;
                    return;
                }
            }

            if (projo == null)
            {
                //creates more
            }
            else
            {
                
            }
            //GameObject projo = Instantiate(shotgunProjo, transform.position, Quaternion.identity);
            if (!isShotGunManual)
            {
                rotateDir = Quaternion.Euler(0, 0, rotationDiff) * attackDir;
            }
            else
            {
                rotateDir = Quaternion.Euler(0, 0, rotationDiff) * mouseDir;
            }
            projo.GetComponent<Rigidbody2D>().AddForce(rotateDir * shotgunSpeed);
            projo.GetComponent<AttackDamage>().damage = shotgunDamage;
            if (shotgunIsPiercing)
            {
                //for piercing module
                projo.GetComponent<AttackDamage>().destroyedOnContact = false;
            }

            if (shotgunIsBurning)
            {
                projo.GetComponent<AttackDamage>().isFireAmmo = true;
            }
            rotationDiff += shotgunSpread;
        }
        #endregion
        */
    }

    IEnumerator RocketShot()
    {
        for (int i = 0; i < rocketNumber; i++)
        {
            GameObject rocket = Instantiate(rocketProjo, transform.position, Quaternion.identity);
            rocket.GetComponent<HomingMissile>().speed = rocketSpeed;
            if (rocketIsResidual)
            {
                rocket.GetComponent<HomingMissile>().isResidual = true;
            }

            if (rocketIsDoubleBounce)
            {
                rocket.GetComponent<HomingMissile>().isDoubleBounce = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void MineLaunch()
    {
        GameObject mine = Instantiate(mineProjo, transform.position, Quaternion.identity);
        mine.GetComponent<Mine>().radius = mineRadius;
        mine.GetComponent<Mine>().damage = mineDamage;
        if (mineIsShrapnel)
        {
            mine.GetComponent<Mine>().isShrapnel = true;
        }

        if (mineIsIce)
        {
            mine.GetComponent<Mine>().isIce = true;
        }
    }

    void FindClosestEnemy()
    {
        if (spawner.enemyPoses.Count != 0)
        {
            //spawner adds each enemy to the array enemies
            enemyPoses = spawner.enemyPoses.ToArray();
            //takes the closest one from the player
            target = GetClosestEnemy(enemyPoses).gameObject;
        }
    }

    IEnumerator ShieldBarrel()
    {
        ShieldShot();
        yield return new WaitForSeconds(0.2f);
        ShieldShot();
    }

    void ShieldShot()
    {
        Transform[] shields;
        if (shieldIsDouble)
        {
            shields = new[] {shieldProjo.transform.GetChild(0), shieldProjo.transform.GetChild(1), shieldProjo.transform.GetChild(2)};
        }
        else
        {
            shields = new[] {shieldProjo.transform.GetChild(0)};
        }

        foreach (var shield in shields)
        {
            Vector2 launchDir = (shield.transform.position - transform.position).normalized;
            GameObject projo = Instantiate(shotgunProjo, shield.transform.position, Quaternion.identity);
            projo.GetComponent<Rigidbody2D>().AddForce(launchDir * 100);
            projo.GetComponent<AttackDamage>().damage = shotgunDamage;
        }
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

    void LookAtMouse()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    IEnumerator Recoil()
    {
        GetComponent<PlayerController>().canMove = false;
        GetComponent<Rigidbody2D>().AddForce(-mouseDir * 500);
        yield return new WaitForSeconds(0.2f);
        GetComponent<PlayerController>().canMove = true;
    }

    void WeaponsPoolingInstances()
    {
        
        
        for (int i = 0; i < 30; i++)
        {
            GameObject projo = Instantiate(shotgunProjo, Vector2.zero, Quaternion.identity);
            bulletsPooling.Add(projo);
            projo.SetActive(false);
        }
        
        for (int i = 0; i < 10; i++)
        {
            GameObject projo = Instantiate(rocketProjo, Vector2.zero, Quaternion.identity);
            rocketsPooling.Add(projo);
            projo.SetActive(false);
        }
        
        for (int i = 0; i < 10; i++)
        {
            GameObject projo = Instantiate(mineProjo, Vector2.zero, Quaternion.identity);
            minesPooling.Add(projo);
            projo.SetActive(false);
        }
/*
        ObjectPool poolComponent = new ObjectPool();
        poolComponent.POOL_SIZE = 30;
        List<GameObject> poolist = poolComponent.PrePool(shotgunProjo);
        foreach (GameObject go in poolist)
        {
            poolComponent.PrePool(go);
        }*/
    }
}
