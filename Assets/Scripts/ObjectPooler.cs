using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour 
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton
    public static ObjectPooler OP;
    private void Awake()
    {
        OP = this;
    }
    #endregion

    private void Start () 
    {
        InitializePool();
    }

    private void InitializePool ()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject instance = Instantiate(pool.prefab, this.transform);
                instance.SetActive(false);
                objectPool.Enqueue(instance);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        GameObject spwaningObject = poolDictionary[tag].Dequeue();
    
        spwaningObject.SetActive(true);
        spwaningObject.transform.position = position;
        spwaningObject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(spwaningObject);

        return spwaningObject;

    }
}
