using UnityEngine;
using System.Collections;

public class drawGUI : MonoBehaviour {
	
	private Texture fireballTex;
	public Texture unclickedFireball;
	public Texture clickedFireball;
	
	private Texture fireblastTex;
	public Texture unclickedFireblast;
	public Texture clickedFireblast;
	
	private Rect buttonSize;
	private Rect button2Size;
	
	private GUIStyle fireballStyle;
	private Variables playerVariables;
	

	// Use this for initialization
	void Start () {
		buttonSize = new Rect(10, 10, 100, 30);
		button2Size = new Rect(10, 50, 100, 30);
		playerVariables = GameObject.Find("PlayerData").GetComponent<Variables>();
		
		fireballTex = unclickedFireball;
		fireblastTex = unclickedFireblast;
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if (GUI.Button(buttonSize, fireballTex))
		{
			fireballTex = clickedFireball;
			fireblastTex = unclickedFireblast;
			playerVariables.currentSpell = (int)SPELLS.Fireball;
		}
		
		if (GUI.Button(button2Size, fireblastTex))
		{
			fireblastTex = clickedFireblast;
			fireballTex = unclickedFireball;
			playerVariables.currentSpell = (int)SPELLS.Fireblast;
		}
	}
}
