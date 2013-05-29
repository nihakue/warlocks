using UnityEngine;
using System.Collections;

public class Windblast: MonoBehaviour {
	
	public GameObject warlock;
	public GameObject spell;
	public float width;
	public float range;
	public float force;
	public float cooldown;
	
	private bool onCooldown;	
	private RaycastHit rayHit;
	private Ray ray;
	

	// Use this for initialization
	void Start () {
		onCooldown = false;
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
				GameObject spellInstance;
					
				//Set the rotation for the instantiated projectile based on mouse click
				Transform tempTran = warlock.transform;
				tempTran.LookAt(rayHit.point);
				warlock.transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
				Quaternion originRotation = Quaternion.Euler(90, tempTran.rotation.eulerAngles.y, 180);
					
				//Instantitate an instance of the spell at the "wand" (shotOrigin) of the wizarrd object
				Vector3 startPosition = warlock.transform.FindChild("Body").FindChild("ShotOrigin").transform.position;
				spellInstance = Instantiate(spell, startPosition, originRotation) as GameObject;
				//Vector3 endPosition = spellInstance.transform.TransformPoint(Vector3.forward * range);
				Blast(spellInstance, startPosition);
				StartCoroutine(TriggerCooldown());
			}
			return true;
		}
		else
			return false;
	}

	
	void Blast(GameObject blastPrefab, Vector3 startPosition)
	{
		
		onCooldown = true;
		Destroy(blastPrefab, 1.0f);
		
	}
	
	IEnumerator TriggerCooldown()
	{
		yield return new WaitForSeconds(cooldown);
		onCooldown = false;
	}
	
}
 