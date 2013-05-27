using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	

	private Rigidbody rb;
	private float squaredLockSpeed;
	private float squaredMagnitude;
	
	private RaycastHit rayHit;
	private Ray ray;
	private Vector3 moveTowards;
	
	private Variables lockStatus;
	private drawGUI gui;
	private SpellSelector spellSelector;
	private float lockSpeed;
	
	// Use this for initialization
	void Start () {	
		lockStatus = GameObject.Find("PlayerData").GetComponent<Variables>();
		spellSelector = GameObject.Find("PlayerData").GetComponent<SpellSelector>();
		gui = GameObject.Find("GUI").GetComponent<drawGUI>();
		SetLockSpeed(lockStatus.speed);
	}
	
	void Awake(){
		//cached rigidbody reference
		rb = rigidbody;
	}
		
	
	// Update is called once per frame
	void Update () {
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
		if (Physics.Raycast(ray, out rayHit))
		{
			Transform tempTran = transform;
			tempTran.LookAt(rayHit.point);
			transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
		}
		
		if (Input.GetButtonDown("Fire1")){
			if (GUIUtility.hotControl == 0){
				if (lockStatus.currentSpell == (int)SPELLS.Movement)
				{
					SetMoveTowards(Input.mousePosition);
				}
				else
					spellSelector.CastSpell(lockStatus.currentSpell);
			}
		}
		
		if (Input.GetButtonDown("Spell1")){
			CastSpell1();
		}
		else if (Input.GetButtonDown("Spell2")){
			CastSpell2();
		}
		else if (Input.GetButtonDown("Spell3")){
			CastSpell3();
		}
		else if (Input.GetButtonDown("Spell4")){
			CastSpell4();
		}
		else if (Input.GetButtonDown ("Spell5")){
			CastSpell5();
		}
		/*
		if (Input.GetKey(KeyCode.D))
			rigidbody.AddForce(new Vector3(lockSpeed, 0, 0));
		if (Input.GetKey(KeyCode.A))
			rigidbody.AddForce(new Vector3(-lockSpeed, 0, 0));
		if (Input.GetKey(KeyCode.W))
			rigidbody.AddForce(new Vector3(0, 0, lockSpeed));
		if (Input.GetKey(KeyCode.S))
			rigidbody.AddForce(new Vector3(0, 0, -lockSpeed));
		*/
		
		
			
		

	
	}
	
	void SetLockSpeed(float lockSpeed)
	{
		this.lockSpeed = lockSpeed;
		squaredLockSpeed = lockSpeed * lockSpeed;
	}
	
	void FixedUpdate(){
		
		//Moves the lock towards the last clicked point
		if (!((moveTowards - transform.position).sqrMagnitude < 1 ))
			MoveTowards();

		
		//Limits the velocity of the lock to it's max speed
		Vector3 lockVelocity = rb.velocity;
		if (lockVelocity.sqrMagnitude > squaredLockSpeed)
			rb.velocity = lockVelocity.normalized * lockSpeed;
		
	}
	
	
	void SetMoveTowards(Vector3 mousePoint)
	{
		Ray ray;
		RaycastHit rayHit;
		ray = Camera.main.ScreenPointToRay(mousePoint);
		if (Physics.Raycast(ray, out rayHit))
			moveTowards = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);	
	}
	
	public void MoveTowardsIs(Vector3 finalPoint)
	{
		moveTowards = finalPoint;
	}
	
	private void MoveTowards()
	{
		Vector3 forceVector = moveTowards - transform.position;
		forceVector = forceVector.normalized * lockStatus.speed;
		rigidbody.AddForce(forceVector);
	}
	

	
	//----------------------Spell Casters------------------------//
	
	void CastSpell1(){
		lockStatus.currentSpell = (int)SPELLS.Fireball;
		gui.SetProjectileCursor();
		if (Input.GetKey(KeyCode.LeftAlt))
			spellSelector.smartCast = true;
	}
	
	void CastSpell2(){
		lockStatus.currentSpell = (int)SPELLS.Fireblast;
		gui.SetProjectileCursor();
		if (Input.GetKey(KeyCode.LeftAlt))
			spellSelector.smartCast = true;
	}
	
	void CastSpell3(){
		lockStatus.currentSpell = (int)SPELLS.Teleport;
		gui.SetProjectileCursor();
		if (Input.GetKey(KeyCode.LeftAlt))
			spellSelector.smartCast = true;
	}
	
	void CastSpell4(){
	}
	
	void CastSpell5(){
	}
}	
