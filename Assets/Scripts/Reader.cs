using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour {

    List<DataPoint> datapoints = new List<DataPoint>();

    void Start(){
        TextAsset csvFile = Resources.Load<TextAsset>("mycsv");
        string[] data = csvFile.text.Split(new char[] {'\n'});

        for(int i = 1; i < data.Length - 1; i++){
            string[] row = data[i].Split(new char[] {','});
            DataPoint dp = new DataPoint();
            dp.label = row[0];
            float.TryParse(row[1], out dp.x);
            float.TryParse(row[2], out dp.y);
            float.TryParse(row[3], out dp.z);
            Debug.Log(dp.GetVector());
            datapoints.Add(dp);
        }
    }

}