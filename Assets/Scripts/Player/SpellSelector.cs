using UnityEngine;
using System.Collections;

public class SpellSelector : MonoBehaviour {
	
	
	private string activeSpell;
	private GameObject playerData;
	public Transform warlock;
	private Variables lockStatus;
	
	private Fireball fireball;
	private Fireblast fireblast;
	private Transform lockSpells;
	private drawGUI gui;
	
	// Use this for initialization
	void Start () {
		playerData = GameObject.Find("PlayerData");
		lockSpells = warlock.transform.FindChild("Spells");
		lockStatus = playerData.GetComponent<Variables>();
		fireball = lockSpells.GetComponent<Fireball>();
		fireblast = lockSpells.GetComponent<Fireblast>();
		gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<drawGUI>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void CastSpell(int chosenSpell){
	
		switch(chosenSpell)
		{
		case (int)SPELLS.Movement:
			Debug.Log("Movement");
			break;
		case (int)SPELLS.Fireball:
			if(fireball.Cast())
			{
				lockStatus.currentSpell = (int)SPELLS.Movement;
				gui.SetHardwareCursor();
				gui.ClearButtons();
			}
			else
				gui.SetCursorStatus("On Cooldown!");
			break;
		case (int)SPELLS.Fireblast:
			if(fireblast.Cast())
			{
				lockStatus.currentSpell = (int)SPELLS.Movement;
				gui.SetHardwareCursor();
				gui.ClearButtons();
			}
			else
				gui.SetCursorStatus("On Cooldown!");
			break;
		}
		
	}
	
}
