using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Reader : Singleton<Reader> {

    List<DataPoint> datapoints = new List<DataPoint>();
    public event Action<List<DataPoint>, Dictionary<string, int>> OnLoadData;

    void Awake(){
        LoadData("foo");
    }

    void LoadData(string filename){
        TextAsset csvFile = Resources.Load<TextAsset>(filename);
        string[] data = csvFile.text.Split(new char[] {'\n'});
        Dictionary<string, int> labelDist = new Dictionary<string, int>();
        for(int i = 1; i < data.Length - 1; i++){
            string[] row = data[i].Split(new char[] {','});
            DataPoint dp = new DataPoint();
            dp.label = row[0];
            float.TryParse(row[1], out dp.x);
            float.TryParse(row[2], out dp.y);
            float.TryParse(row[3], out dp.z);
            Vector3 vec = dp.GetVector() + Constants.Instance.origin;
            // Debug.Log(vec + "---" + dp.GetVector()+ "" +Constants.Instance.origin);
            datapoints.Add(dp);
            try{
                labelDist.Add(dp.label, 1);
            }
            catch(ArgumentException){
                labelDist[dp.label] += 1;
            }
        }
        // Debug.Log(labelDist.Count);
        Debug.Log("loaded");
        if(OnLoadData != null){
            Debug.Log(message: "doneThis", context: this);
            OnLoadData(datapoints, labelDist);
        }
        else{
            Debug.Log(message: "notdone", context: this);
        }
    }
}