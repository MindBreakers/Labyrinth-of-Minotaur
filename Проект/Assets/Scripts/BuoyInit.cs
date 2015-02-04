using UnityEngine;
using System.Collections;

public class BuoyInit : MonoBehaviour {
	public Light glow;

	// Use this for initialization
	void Start () {
		Destroy (GetComponent<MeshRenderer> ());
		Destroy (glow);
		Destroy (this);
	
	}
	

}
