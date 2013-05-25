using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	
	public float lockSpeed;
	

	private Rigidbody rb;
	private float squaredLockSpeed;
	private float squaredMagnitude;
	
	private RaycastHit rayHit;
	private Ray ray;
	private Transform trans;
	
	private Variables lockStatus;
	private SpellSelector spellSelector;
	
	// Use this for initialization
	void Start () {
		lockStatus = GameObject.Find("PlayerData").GetComponent<Variables>();
		spellSelector = GameObject.Find("PlayerData").GetComponent<SpellSelector>();
	}
	
	void Awake(){
		//cached rigidbody reference
		rb = rigidbody;
		SetLockSpeed(lockSpeed);
		
		//cached transform reference 
		trans = transform;
	}
		
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1"))
			if (GUIUtility.hotControl == 0)
				spellSelector.CastSpell(lockStatus.currentSpell);
		if (Input.GetKey(KeyCode.D))
			rigidbody.AddForce(new Vector3(lockSpeed, 0, 0));
		if (Input.GetKey(KeyCode.A))
			rigidbody.AddForce(new Vector3(-lockSpeed, 0, 0));
		if (Input.GetKey(KeyCode.W))
			rigidbody.AddForce(new Vector3(0, 0, lockSpeed));
		if (Input.GetKey(KeyCode.S))
			rigidbody.AddForce(new Vector3(0, 0, -lockSpeed));
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayHit))
			{
				Transform tempTran = transform;
				tempTran.LookAt(rayHit.point);
				transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
			}
	
	}
	
	void SetLockSpeed(float lockSpeed)
	{
		this.lockSpeed = lockSpeed;
		squaredLockSpeed = lockSpeed * lockSpeed;
	}
	
	void FixedUpdate(){
		//Limits the velocity of the lock to it's max speed
		Vector3 lockVelocity = rb.velocity;
		if (lockVelocity.sqrMagnitude > squaredLockSpeed)
			rb.velocity = lockVelocity.normalized * lockSpeed;
	}
	
		
}	
