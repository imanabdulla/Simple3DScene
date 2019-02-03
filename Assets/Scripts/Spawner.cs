using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    private ObjectPooler OP;

    private float xPos;
    private float yPos;
    private float zPos;
    private float xScale;
    private float zScale;

    private void Start()
    {
        this.OP = ObjectPooler.OP;

        xPos    = this.transform.position.x;
        yPos    = this.transform.position.y;
        zPos    = this.transform.position.z;
        xScale  = this.transform.localScale.x;
        zScale  = this.transform.localScale.z;
        InvokeRepeating("SetSpawningObject", 1, 1f);
    }

    private void SetSpawningObject()
    {
        float x = UnityEngine.Random.Range(-13, 13);
        float z = UnityEngine.Random.Range(0, 24);

        GameObject _spawningObject = OP.SpawnFromPool("Cube", new Vector3(x, yPos, z), Quaternion.identity);

    }
}
