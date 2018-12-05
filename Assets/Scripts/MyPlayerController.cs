using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour {

    public int speed = 1;
	public Transform PointsParent;
	public Mesh newMesh;
	public float scale;
	void Awake(){
		// add listners
		Debug.Log("Called");
		PointsParent = GameObject.Find("Points").transform;
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
			/*
			Debug.Log("GOT RIFT/VR");
			string[] a = Input.GetJoystickNames();
			for(int i = 0; i < a.Length; i++) {
      			Debug.Log(a[i]);
    		}
			if(OVRInput.Get(OVRInput.Button.One)){
				Debug.Log("Pressed");
			}
			*/
			// get input data from keyboard or controller
			float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            // update player position based on input
            Vector3 position = PointsParent.position;
            position.x += moveHorizontal * speed * Time.deltaTime;
            position.z += moveVertical * speed * Time.deltaTime;
            PointsParent.position = position;
		}
		if (Input.GetButtonDown("Oculus_CrossPlatform_Button2")){
      		PointsParent.Rotate(Vector3.up * speed * 100 * Time.deltaTime);
		}
      
		if (Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
			PointsParent.Rotate(-Vector3.up * speed * 100 * Time.deltaTime);
	}

	void drawIt(List<DataPoint> dataPoints, Dictionary<string, int> labelDict){
		Debug.Log("added");
		// PrintDict(labelDict);
		Debug.Log(dataPoints.Count);
		foreach(DataPoint dp in dataPoints){

			GameObject unit = Resources.Load("Prefabs/BasicSphere_2") as GameObject;
			if (newMesh != null)
			{
				unit.GetComponent<MeshFilter>().mesh = newMesh;
				unit.transform.localScale = new Vector3(scale, scale, scale);
			}
			// position it
			GameObject newObj = Instantiate(unit, dp.GetVector(), new Quaternion(0,0,0,0));
			//newObj.GetComponent<BlockMat>().AddColor((float)(dp.GetFloatLabel()/labelDict.Count));
			//newObj.GetComponent<Renderer>().sharedMaterial.color = new Color(0,(dp.GetFloatLabel()/labelDict.Count)*1,0,1.0f);
			newObj.GetComponent<ChangeShaderGraphColor>().AddColor(dp.GetFloatLabel() / labelDict.Count);

			if (Constants.Instance.sphere)
			{
				newObj.transform.LookAt(PointsParent.position - dp.GetVector());
				newObj.transform.rotation *= Quaternion.Euler(90, 0, 0);
			}
			newObj.transform.SetParent(PointsParent);
		}
	}

	void PrintDict(Dictionary<string, int> DICT){
		foreach (KeyValuePair<string, int> pair in DICT) {
			Debug.LogFormat("{0} : {1}", pair.Key, pair.Value);
		}
    }
	
}
