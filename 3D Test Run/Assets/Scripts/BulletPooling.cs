using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int poolSize;
    }

    #region Singleton

    public static BulletPooling Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject bullet = Instantiate(pool.prefab);
                bullet.SetActive(false);
                objectPool.Enqueue(bullet);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("pool with tag " + tag + " doesnt exist!!!!!!!");
            Debug.LogWarning("pool with tag " + tag + " doesnt exist!!!!!!!");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();



        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);    

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    void Update()
    {

    }
}
