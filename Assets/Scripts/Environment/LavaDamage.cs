using UnityEngine;
using System.Collections;

public class LavaDamage : MonoBehaviour {
	
	private Variables lockStatus;
	private float tick;
	private float timeElapsed;
	private float fireResist;
	// Use this for initialization
	void Start () {
		lockStatus = GameObject.Find("PlayerData").GetComponent<Variables>();
		tick = 0.2f;
		timeElapsed = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Body")
			fireResist = lockStatus.fireResistance;
		
		//half the rate of damage intake for every 100 fire resist the player has
		tick = tick * (1.0f + (fireResist/100.0f));
	}
	
	void OnCollisionStay(Collision collision)
	{
		if (collision.collider.name == "Body")
		{
			timeElapsed += Time.deltaTime;
			if(timeElapsed > tick){
				lockStatus.currentHealth -= 1;
				timeElapsed = 0.0f;
			}
		}
			
	}
	
}
