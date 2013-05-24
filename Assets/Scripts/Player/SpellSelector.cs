using UnityEngine;
using System.Collections;

public class SpellSelector : MonoBehaviour {
	
	
	private string activeSpell;
	private GameObject playerData;
	public GameObject warlock;
	private Variables playerVariables;
	
	private Fireball fireball;
	private Fireblast fireblast;
	
	// Use this for initialization
	void Start () {
		playerData = GameObject.Find("PlayerData");
		playerVariables = playerData.GetComponent<Variables>();
		fireball = warlock.GetComponent<Fireball>();
		fireblast = warlock.GetComponent<Fireblast>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void CastSpell(SPELLS chosenSpell){
	
		switch(chosenSpell)
		{
		case SPELLS.Fireball:
			fireball.Cast();
			break;
		case SPELLS.Fireblast:
			fireblast.Cast();
			break;
		}
		
	}
}
