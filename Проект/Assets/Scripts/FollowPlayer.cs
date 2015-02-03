using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	NavMeshAgent agent;
	Animator anim;

	// Use this for initialization
	void Start () {
		agent=GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = player.transform.position;
		anim.SetInteger ("speed", 1);
		rigidbody.transform.Translate (Vector3.forward * Time.deltaTime*3f);
	
	}
}
