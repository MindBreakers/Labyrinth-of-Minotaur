using UnityEngine;
using System.Collections;

public class Footsteps_handler : MonoBehaviour {
	public SphereCollider leftfootcollider,rightfootcollider;
	public AudioClip[] footsounds;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider footcollider) {
		int max;
		int val;
		max = footsounds.Length;
		val = Random.Range (0, max);
			audio.PlayOneShot(footsounds[val]);
			Debug.Log("foot");
		}
	}


