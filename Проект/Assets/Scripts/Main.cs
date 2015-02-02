using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject taur;
	public GameObject you;
	public AudioSource close;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(taur.transform.position,you.transform.position)<=0.5f) {close.Play();}
	}
}
