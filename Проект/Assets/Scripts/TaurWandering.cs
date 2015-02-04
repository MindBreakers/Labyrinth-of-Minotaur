using UnityEngine;
using System.Collections;

public class TaurWandering : MonoBehaviour {
	public GameObject[] checkpoints;
	public GameObject taur;
	public GameObject Taurdest;

	// Use this for initialization
	void Start () {
		Taurdest.transform.position = taurnextdest ().transform.position;
	}
	GameObject taurnextdest(){
		int max;
		int val;
		Debug.Log ("Finddest");
		max = checkpoints.Length;
		val = Random.Range (0, max);
		return checkpoints[val];
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (taur.transform.position, Taurdest.transform.position) <= 2f) {
			Taurdest.transform.position = taurnextdest ().transform.position;
		}
	
	}
}
