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
        Vector3 pos = new Vector3(x, y, z);
        Debug.LogFormat("{0}=={1}", pos, Constants.Instance.minRad);
        //pos = Vector3.Scale(pos, Constants.Instance.minRad);
        return pos*10;
    }

    public float GetFloatLabel(){
        float labelfloat = -1;
        float.TryParse(label, out labelfloat);
        return labelfloat;
    }
}