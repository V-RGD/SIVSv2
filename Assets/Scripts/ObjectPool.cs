using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<List<GameObject>> GameObjectPools;
    List<GameObject> GameObjectPool;
    GameObject Temp;
    public int POOL_SIZE;
    public int GROWTH_SIZE;

    int Counter;

    // Use this for initialization
    void Start()
    {
        Counter = 0;
        GameObjectPools = new List<List<GameObject>>();

    }

    void FixedUpdate()
    {
    }

    public GameObject RetrieveObject(GameObject BaseObject)
    {
        foreach (List<GameObject> Item in GameObjectPools)
        {
            Temp = Item[0];
            if ((Temp.name == (BaseObject.name + "(Clone)") || Temp.name == BaseObject.name) && Item.Count > 1)
            {
                Item.RemoveAt(0);
                Temp.SetActive(true);
                Counter++;
                return Temp;
            }
        }

        throw new System.NullReferenceException("RetrieveObject(BaseObject)  BaseObject is not pooled, null error");
    }

    public bool PoolObject(GameObject BaseObject)
    {
        foreach (List<GameObject> Item in GameObjectPools)
        {
            Temp = Item[0];
            if (Temp.name == BaseObject.name)
            {
                BaseObject.SetActive(false);
                Item.Add(BaseObject);
                return true;
            }
        }

        throw new System.NullReferenceException("PoolObject(BaseObject)  BaseObject is not pooled, null error");
        return false;
    }

    IEnumerator PrePoolHelper(List<GameObject> GameObjectPool, GameObject BaseObject)
    {
        for (int counter = 0; counter < POOL_SIZE; counter++)
        {
            Temp = Instantiate(BaseObject) as GameObject;
            Temp.SetActive(false);
            GameObjectPool.Add(Temp);
            if (counter % GROWTH_SIZE == 0)
            {
                yield return new WaitForEndOfFrame();
            }
        }

        GameObjectPools.Add(GameObjectPool);
    }

    public void PrePool(GameObject BaseObject)
    {
        GameObjectPool = new List<GameObject>();
        StartCoroutine(PrePoolHelper(GameObjectPool, BaseObject));
    }
}