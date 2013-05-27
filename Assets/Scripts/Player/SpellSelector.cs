using UnityEngine;
using System.Collections;

public class SpellSelector : MonoBehaviour {
	
	
	private string activeSpell;
	private GameObject playerData;
	public Transform warlock;
	public bool smartCast;
	
	
	private Variables lockStatus;
	
	private Fireball fireball;
	private Fireblast fireblast;
	private Teleport teleport;
	private Transform lockSpells;
	private drawGUI gui;
	
	// Use this for initialization
	void Start () {
		playerData = GameObject.Find("PlayerData");
		lockSpells = warlock.transform.FindChild("Spells");
		lockStatus = playerData.GetComponent<Variables>();
		fireball = lockSpells.GetComponent<Fireball>();
		fireblast = lockSpells.GetComponent<Fireblast>();
		teleport = lockSpells.GetComponent<Teleport>();
		gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<drawGUI>();
		
		smartCast = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (smartCast){
			CastSpell(lockStatus.currentSpell);
			smartCast = false;
		}
	
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
				ClearStatus();
			}
			else
				gui.SetCursorStatus("On Cooldown!");
				ClearStatus();
			break;
		case (int)SPELLS.Fireblast:
			if(fireblast.Cast())
			{
				ClearStatus();
			}
			else{
				gui.SetCursorStatus("On Cooldown!");
				ClearStatus();
			}
			break;
		
			
		case (int)SPELLS.Teleport:
			if (teleport.Cast())
			{
				ClearStatus();
			}
			else {
				gui.SetCursorStatus("On Cooldown!");
				ClearStatus();
			}
			break;
		}
		
	}
	
	void ClearStatus()
	{
		lockStatus.currentSpell = (int)SPELLS.Movement;
		gui.SetHardwareCursor();
		gui.ClearButtons();
	}
	
}
