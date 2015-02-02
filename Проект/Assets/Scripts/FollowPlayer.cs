using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent=GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = player.transform.position;
	
	}
}
