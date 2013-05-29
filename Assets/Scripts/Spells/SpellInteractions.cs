using UnityEngine;
using System.Collections;
using System;

public class SpellInteractions : MonoBehaviour {

	private bool spellCollision;
	
	private string spell1 = "Fireball(Clone)";
	private string spell2 = "Fireblast(Clone)";
	private string spell3 = "Teleport(Clone)";
	private string spell4 = "WindBlast(Clone)";
	
	public GameObject spell2spell4;
	
	private string[] spellList;
	// Use this for initialization
	void Start () {
		spellCollision = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	
	public void StartInteraction(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
		string n1 = firstSpell.name;
		string n2 = secondSpell.name;
	
		if ((n1 == spell2 || n2 == spell2) && (n1 == spell4 || n2 == spell4))
			Debug.Log("Old Sport");
		
		if ((n1 == spell1 || n2 == spell1) && (n1 == spell1) || n2 == spell1)
			Spell1Spell1(collider, firstSpell, secondSpell);
		else if ((n1 == spell1 || n2 == spell1) && (n1 == spell2) || n2 == spell2)
			Spell1Spell1(collider, firstSpell, secondSpell);
		else if ((n1 == spell1 || n2 == spell1) && (n1 == spell3) || n2 == spell3)
			Spell1Spell1(collider, firstSpell, secondSpell);
		else if ((n1 == spell1 || n2 == spell1) && (n1 == spell4) || n2 == spell4)
			Spell1Spell1(collider, firstSpell, secondSpell);
		
		
		
		else if ((n1 == spell2 || n2 == spell2) && (n1 == spell2) || n2 == spell2)
			Spell2Spell2(collider, firstSpell, secondSpell);
		else if ((n1 == spell2 || n2 == spell2) && (n1 == spell3) || n2 == spell3)
			Spell2Spell3(collider, firstSpell, secondSpell);
		if ((n1 == spell2 || n2 == spell2) && (n1 == spell4 || n2 == spell4))
			Spell2Spell4(collider, firstSpell, secondSpell);
		
		
		else if ((n1 == spell3 || n2 == spell3) && (n1 == spell3) || n2 == spell3)
			Spell2Spell2(collider, firstSpell, secondSpell);
		else if ((n1 == spell3 || n2 == spell3) && (n1 == spell4) || n2 == spell4)
			Spell2Spell3(collider, firstSpell, secondSpell);
		
		else if ((n1 == spell4 || n2 == spell4) && (n1 == spell4) || n2 == spell4)
			Spell2Spell4(collider, firstSpell, secondSpell);
				
	}
	
	private void Spell1Spell1(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	private void Spell1Spell2(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	private void Spell1Spell3(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}	
	private void Spell1Spell4(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	
	
	private void Spell2Spell2(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	private void Spell2Spell3(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	private void Spell2Spell4(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
		GameObject spellInstance;
		spellInstance = Instantiate(spell2spell4, secondSpell.transform.position, firstSpell.transform.rotation) as GameObject;
		Destroy(spellInstance, 5.0f);
		Destroy(secondSpell.gameObject);
			
	}
	
	
	private void Spell3Spell3(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	private void Spell3Spell4(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	
	
	private void Spell4Spell4(Collider collider, GameObject firstSpell, GameObject secondSpell)
	{
	}
	
	
}
