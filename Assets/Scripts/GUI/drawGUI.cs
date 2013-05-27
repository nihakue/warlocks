using UnityEngine;
using System.Collections;

public class drawGUI : MonoBehaviour {
	
	private Texture fireballTex;
	public Texture unclickedFireball;
	public Texture clickedFireball;
	
	private Texture fireblastTex;
	public Texture unclickedFireblast;
	public Texture clickedFireblast;
	
	public Texture2D projectileCursor;
	
	private Rect buttonSize;
	private Rect button2Size;
	private Rect button3Size;
	
	private GUIStyle fireballStyle;
	private Variables lockStatus;
	
	//Status text centered on cursor
	private string cursorStatusText;
	

	// Use this for initialization
	void Start () {
		buttonSize = new Rect(10, 10, 100, 30);
		button2Size = new Rect(10, 50, 100, 30);
		button3Size = new Rect(10, 90, 100, 30);
		lockStatus = GameObject.Find("PlayerData").GetComponent<Variables>();
		
		fireballTex = unclickedFireball;
		fireblastTex = unclickedFireblast;
		
		cursorStatusText = "";
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if (GUI.Button(buttonSize, fireballTex))
		{
			fireballTex = clickedFireball;
			ClearButtons(fireballTex);
			lockStatus.currentSpell = (int)SPELLS.Fireball;
			SetProjectileCursor();
		}
		
		if (GUI.Button(button2Size, fireblastTex))
		{
			fireblastTex = clickedFireblast;
			ClearButtons(fireblastTex);
			lockStatus.currentSpell = (int)SPELLS.Fireblast;
			SetProjectileCursor();
		}
		
		if (GUI.Button(button3Size, "Teleport"))
		{
			ClearButtons(fireblastTex);
			lockStatus.currentSpell = (int)SPELLS.Teleport;
			SetProjectileCursor();
		}
		
		//Displays whether or not there is a cooldown for a spell. Until better system in place.
		GUI.Label(new Rect(Screen.width/2, Screen.height/1.1f, 500, 50), cursorStatusText);
		
		GUI.Label(new Rect(Screen.width/2, Screen.height/1.2f, 500, 50), lockStatus.currentHealth + " / " + lockStatus.maxhealth);
	}
	
	public void SetProjectileCursor(){
		
		Cursor.SetCursor(projectileCursor, Vector2.zero, CursorMode.ForceSoftware);
	}
	
	public void SetHardwareCursor(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
	
	//Clears the active spell button graphics
	//Parameters: Optional Texture will not clear
	public void ClearButtons(Texture dontClear = null){
		if (!dontClear == fireballTex)
			fireballTex = unclickedFireball;
		if (!dontClear == fireblastTex)
			fireblastTex = unclickedFireblast;
	}
	
	public void SetCursorStatus(string status){
		cursorStatusText = status;
		StartCoroutine(statusTextFade());
	}
	
	IEnumerator statusTextFade(){
		yield return new WaitForSeconds(2);
		cursorStatusText = "";
	}

}
