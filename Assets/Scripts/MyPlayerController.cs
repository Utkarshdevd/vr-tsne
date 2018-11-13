using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour {

    public int speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Input.GetJoystickNames());
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
}
