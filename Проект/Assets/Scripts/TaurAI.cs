using UnityEngine;
using System.Collections;

public class TaurAI : MonoBehaviour {
	public GameObject player;
	public GameObject Taurdest;
	public float angle=90f;
	public float stalktime=5f;
	public GameObject[] checkpoints;
	public string taurstate;
	public float wanderingspeed=2f,chasingspeed=3f,attackcd=5;
	NavMeshAgent agent;
	Animator anim;
	private SphereCollider DetectionSphere;
	private float lastseen=0.0f,lastattack=0.0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		DetectionSphere = GetComponent<SphereCollider>();
		Taurdest.transform.position = taurnextdest ().transform.position;
		taurstate = "wandering";
		agent.destination = Taurdest.transform.position;
	}
	GameObject taurnextdest(){
		int max;
		int val;
		max = checkpoints.Length;
		val = Random.Range (0, max);
		return checkpoints[val];
	}
	
	// Update is called once per frame
	void Update () {
		if (taurstate == "wandering") {								//Player chase or wandering
			if (Vector3.Distance (transform.position, Taurdest.transform.position) <= 2f) {
				Taurdest.transform.position = taurnextdest ().transform.position;
			}
			agent.destination = Taurdest.transform.position;
			anim.SetInteger ("speed", 1);
			rigidbody.transform.Translate (Vector3.forward * Time.deltaTime * wanderingspeed);
		}
		if (taurstate == "chasing") {
			agent.destination = player.transform.position;
			rigidbody.transform.Translate (Vector3.forward * Time.deltaTime * chasingspeed);
			anim.SetInteger ("speed", 1);
		}
		if (taurstate == "attacking") {
			anim.SetInteger ("speed", 0);
			if(lastattack+attackcd<=Time.time){
				anim.Play("Attacking",-1,0);
				lastattack=Time.time;}
		}
	}
	void OnTriggerStay(Collider DetectionSphere) {
		if (DetectionSphere.gameObject == player) {
			Vector3 direction = DetectionSphere.transform.position - transform.position;
			float tempangle = Vector3.Angle(direction, transform.forward);
			if(tempangle<=angle*0.5f){
				if (Vector3.Distance (transform.position, player.transform.position) <= 2f) {
					taurstate = "attacking";}else {taurstate="chasing";}
			lastseen=Time.time+stalktime;}}
		if(Time.time>lastseen){taurstate="wandering";}
	}
}
