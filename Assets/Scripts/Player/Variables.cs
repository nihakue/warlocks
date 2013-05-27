using UnityEngine;
using System.Collections;

public enum SPELLS{Movement, Fireball, Fireblast, Teleport};


public class Variables : MonoBehaviour {
	
	public int maxhealth;
	public int currentHealth;
	public int fireResistance;
	public int knockbackResistance;
	public int speed;
	public int currentSpell;
	

	// Use this for initialization
	void Start () {
		maxhealth = 100;
		currentHealth = maxhealth;
		knockbackResistance = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
