using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour {

    public int speed = 0;

	void Awake(){
		// add listners
		Debug.Log("Called");
		Reader.Instance.OnLoadData += drawIt;
	}

	void OnDisable(){
		// remove listners
	}
	// Use this for initialization
	void Start () {
		// Load default data or load selection screen
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetJoystickNames() == null){
			// get input data from keyboard or controller
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			// update player position based on input
			Vector3 position = transform.position;
			position.x += moveHorizontal * speed * Time.deltaTime;
			position.z += moveVertical * speed * Time.deltaTime;
			transform.position = position;
		}
		else{
			Debug.Log("GOT RIFT/VR");
			string[] a = Input.GetJoystickNames();
			for(int i = 0; i < a.Length; i++) {
      			Debug.Log(a[i]);
    		}
			// get input data from keyboard or controller
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			// update player position based on input
			Vector3 position = transform.position;
			position.x += moveHorizontal * speed * Time.deltaTime;
			position.z += moveVertical * speed * Time.deltaTime;
			transform.position = position;
		}
	}

	void drawIt(List<DataPoint> dataPoints){
		Debug.Log("added");
		Debug.Log(dataPoints.Count);
		foreach(DataPoint dp in dataPoints){
			// get current prefab
			GameObject unit = Resources.Load("Prefabs/BasicSphere") as GameObject;
			// position it
			Instantiate(unit, dp.GetVector(), new Quaternion(0,0,0,0));
		}
	}
}
