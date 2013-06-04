using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	
	public enum CONTROL_TYPE {Gamepad, Mouse};
	
	public CONTROL_TYPE controlType;
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
		
		//TO DO: This control type may be a hack
			if (controlType == CONTROL_TYPE.Mouse)
			{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
			if (Physics.Raycast(ray, out rayHit))
			{
				Transform tempTran = transform;
				tempTran.LookAt(rayHit.point);
				transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
			}
			
			if (Input.GetButtonDown("Movement")){
				SetMoveTowards(Input.mousePosition);
			}
		
		
			if (Input.GetButtonDown("Fire1")){
				if (GUIUtility.hotControl == 0){
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
			
		}
		
		if (controlType == CONTROL_TYPE.Gamepad)
		{
				
			if (Input.GetAxis("Horizontal") != 0)
			{
				float axisValue = Input.GetAxis("Horizontal");
				rigidbody.AddForce(new Vector3(lockSpeed*axisValue, 0, 0));
			}
			
			if (Input.GetAxis("Vertical") != 0)
			{
				float axisValue = Input.GetAxis("Vertical");
				rigidbody.AddForce(new Vector3(0, 0, lockSpeed*axisValue));
			}
			//TODO: Fixed this shit
			if (Input.GetAxis("HorizontalLook") != 0 || Input.GetAxis("VerticalLook") != 0)
			{
				float xAxisValue = Input.GetAxis("HorizontalLook");
				float yAxisValue = Input.GetAxis("VerticalLook");
				/*float radian = Mathf.Asin(xAxisValue);
				float degrees = radian * Mathf.Rad2Deg;
				if (yAxisValue > 0)
					degrees = 360 - degrees;
				
				Debug.Log(degrees);
				
				*/				
				float degrees = Mathf.Atan2( -yAxisValue , xAxisValue) * Mathf.Rad2Deg;
				
				Debug.Log( degrees) ;
				
				Quaternion direction = Quaternion.Euler(0, -degrees, 0);
				transform.rotation = direction;
				
			}
			
			
			if (Input.GetButtonDown("Fire2")){
				CastSpell1();
			}
			
			if (Input.GetButtonDown("Fire3")){
				CastSpell2();
			}
			
			if (Input.GetButtonDown("Fire4")){
				CastSpell3();
			}
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
		//if (!((moveTowards - transform.position).sqrMagnitude < 1 ))
		//	MoveTowards();

		
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
		
		if (controlType == CONTROL_TYPE.Mouse)
		{
			lockStatus.currentSpell = (int)SPELLS.Fireball;
			gui.SetProjectileCursor();
			if (Input.GetKey(KeyCode.LeftAlt))
				spellSelector.smartCast = true;
		}
		else if (controlType == CONTROL_TYPE.Gamepad)
		{
			lockStatus.currentSpell = (int)SPELLS.Fireball;
			spellSelector.smartCast = true;
		}
	}
	
	void CastSpell2(){
		if (controlType == CONTROL_TYPE.Mouse)
		{
			lockStatus.currentSpell = (int)SPELLS.Fireblast;
			gui.SetProjectileCursor();
			if (Input.GetKey(KeyCode.LeftAlt))
				spellSelector.smartCast = true;
		}
		else if (controlType == CONTROL_TYPE.Gamepad)
		{
			lockStatus.currentSpell = (int)SPELLS.Fireblast;
			spellSelector.smartCast = true;
		}
	}
	
	void CastSpell3(){
		if (controlType == CONTROL_TYPE.Mouse)
		{
			lockStatus.currentSpell = (int)SPELLS.Teleport;
			gui.SetProjectileCursor();
			if (Input.GetKey(KeyCode.LeftAlt))
				spellSelector.smartCast = true;
		}
		else if (controlType == CONTROL_TYPE.Gamepad)
		{
			lockStatus.currentSpell = (int)SPELLS.Teleport;
			spellSelector.smartCast = true;
		}
	}
	
	void CastSpell4(){
		if (controlType == CONTROL_TYPE.Mouse)
		{
			lockStatus.currentSpell = (int)SPELLS.Windblast;
			gui.SetProjectileCursor();
			if (Input.GetKey(KeyCode.LeftAlt))
				spellSelector.smartCast = true;
		}
		else if (controlType == CONTROL_TYPE.Gamepad)
		{
			lockStatus.currentSpell = (int)SPELLS.Windblast;
			spellSelector.smartCast = true;
		}
	}
	
	void CastSpell5(){
	}
}	
