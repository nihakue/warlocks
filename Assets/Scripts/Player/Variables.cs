using UnityEngine;
using System.Collections;

public enum SPELLS{Movement, Fireball, Fireblast};


public class Variables : MonoBehaviour {
	
	public int health;
	public int fireResistance;
	public int knockbackResistance;
	public int speed;
	public int currentSpell;
	

	// Use this for initialization
	void Start () {
		health = 100;
		speed = 3;
		fireResistance = 1;
		knockbackResistance = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
