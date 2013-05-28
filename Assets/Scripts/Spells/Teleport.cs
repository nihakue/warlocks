using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public GameObject warlock;
	//Spell graphic must be a prefab
	public GameObject spellGraphic;
	public float range;
	public float cooldown;
	
	private GameObject spellInstance;
	private bool onCooldown;	
	private RaycastHit rayHit;
	private Ray ray;
	private CharacterControls controls;
	

	// Use this for initialization
	void Start () {
		onCooldown = false;
		controls = warlock.GetComponent<CharacterControls>();
	}
	
	void Awake() {
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public bool Cast(){
		if (!onCooldown)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayHit))
			{
				onCooldown = true;
				Vector3 toPosition = new Vector3 (rayHit.point.x, warlock.transform.position.y+.2f, rayHit.point.z);
				Vector3 difference = toPosition - warlock.transform.position;
				if (difference.magnitude >range){
					difference = difference.normalized * range;
					toPosition = warlock.transform.position + difference;
				}
					
				//Set the new position for the warlock based on 
				warlock.rigidbody.MovePosition(toPosition);
				controls.MoveTowardsIs(toPosition);
					
				//Instantitate an instance of the spell at the "wand" (shotOrigin) of the wizarrd object
				Vector3 startPosition = warlock.transform.position;
				spellInstance = Instantiate(spellGraphic, startPosition, warlock.transform.rotation) as GameObject;
				StartCoroutine(TriggerCooldown());
				StartCoroutine(SpellEffectsTimer());
			}
			
			return true;
		}
		else
			return false;
		
	}
	
	IEnumerator TriggerCooldown()
	{
		yield return new WaitForSeconds(cooldown);
		onCooldown = false;
	}
	
	IEnumerator SpellEffectsTimer()
	{
		yield return new WaitForSeconds(.5f);
		Destroy(spellInstance);
	}
	
}
