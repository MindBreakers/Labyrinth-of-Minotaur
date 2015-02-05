using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	public GameObject Taurdest;
	public bool chasingplayer=false;
	public float angle=90f;
	public float stalktime=5f;
	NavMeshAgent agent;
	Animator anim;
	private SphereCollider DetectionSphere;
	private float lastseen=0.0f;
	// Use this for initialization
	void Start () {
		agent=GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		DetectionSphere = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(chasingplayer==true)
		{agent.destination = player.transform.position;}
		else {agent.destination = Taurdest.transform.position;};
		anim.SetInteger ("speed", 1);
		rigidbody.transform.Translate (Vector3.forward * Time.deltaTime*3f);
	
	}
	void OnTriggerStay(Collider DetectionSphere) {
		if (DetectionSphere.gameObject == player) {
			Vector3 direction = DetectionSphere.transform.position - transform.position;
			float tempangle = Vector3.Angle(direction, transform.forward);
			Debug.Log(tempangle);
			if(tempangle<=angle*0.5f){chasingplayer=true;lastseen=Time.time+stalktime;}
		}else if(Time.time>lastseen){chasingplayer=false;}
	}
}