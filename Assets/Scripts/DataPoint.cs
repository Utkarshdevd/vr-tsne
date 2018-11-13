using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPoint{
    public GameObject prefab;
    
    public float x;
    public float y;
    public float z;
    public string label;

    public Vector3 GetVector(){
        return new Vector3(x, y, z);
    }
}