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
    public float rocketSpeed = 3;

    public Vector2 attackDir;
    public GameObject target;
    
    public Transform[] enemyPoses;
    private Spawner spawner;
    
    //for timer purposes only
    private float shotgunTimer;
    private float rocketTimer;
    private float mineTimer;
    private float shieldRotation;
    
    //cooldown for all weapons
    public float shotgunCooldown = 2;
    public float rocketCooldown = 4;
    public float mineCooldown = 3;

    public bool isShotGunManual = true;
    private Vector2 mousePos;
    private Vector2 mouseDir;
    public Camera cam;

    private void Awake()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
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
                RocketShot();
            }

            if (mineTimer <= 0 && isMinesActive)
            {
                mineTimer = mineCooldown/mineRate;
                MineLaunch();
            }
        }

        if (isShieldActive)
        {
            shieldProjo.SetActive(true);
            //rotates around players
            shieldRotation += Time.deltaTime * 360 * shieldSpeed;
            shieldProjo.transform.rotation = Quaternion.Euler(0, 0, shieldRotation);

            if (shieldRotation > 360)
            {
                shieldRotation = 0;
            }
        }

        shotgunTimer -= Time.deltaTime;
        rocketTimer -= Time.deltaTime;
        mineTimer -= Time.deltaTime;
    }
    void ShotgunShot()
    {
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
            rotationDiff += shotgunSpread;
        }
    }

    void RocketShot()
    {
        GameObject rocket = Instantiate(rocketProjo, transform.position, Quaternion.identity);
        rocket.GetComponent<HomingMissile>().speed = rocketSpeed;
    }

    void MineLaunch()
    {
        Instantiate(mineProjo, transform.position, Quaternion.identity);
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
}
