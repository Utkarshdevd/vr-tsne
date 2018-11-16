using System.Collections.Generic;
using UnityEngine;

public class Constants : Singleton<Constants> {
	protected Constants () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	//declare constants here
	public Vector3 origin;
	public Vector3 minRad;
	public int minSphereRad;
	public bool sphere;

	void Awake(){
		// set constants here
		origin = new Vector3(1, 1, 1);
		minSphereRad = 1000;
		minRad = new Vector3(minSphereRad, minSphereRad, minSphereRad);
	}
}