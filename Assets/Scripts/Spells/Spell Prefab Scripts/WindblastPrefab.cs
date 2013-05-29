using UnityEngine;
using System.Collections;

public class WindblastPrefab : MonoBehaviour {
	
	public float force;
	public GameObject fireblastInteraction;
	
	
	private float tick = .1f;
	private float timeElapsed = 0;
	private Vector3 forceDirection;
	private SpellInteractions spellInteractions;
	// Use this for initialization
	void Start () {
		spellInteractions = GameObject.Find("PlayerData").GetComponent<SpellInteractions>();
		
	}
	
	void Wake(){
	forceDirection = transform.position;
	}
		
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerStay(Collider other){
		if (other.name == "Box"){
			timeElapsed = timeElapsed + Time.deltaTime;
			if (timeElapsed > tick){
				forceDirection = other.transform.position - transform.position;
				other.rigidbody.AddForce(forceDirection * force);
				timeElapsed = 0;
			}
		}
		
		if(other.CompareTag("Spell"))
		{
			spellInteractions.StartInteraction(other, this.gameObject, other.gameObject);
		}
	

	}
}
