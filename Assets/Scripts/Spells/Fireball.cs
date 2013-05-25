using UnityEngine;
using System.Collections;

public class Fireball: MonoBehaviour {
	
	public GameObject warlock;
	public GameObject spell;
	public float shootSpeed;
	public float range;
	public float cooldown;
	
	private bool onCooldown;	
	private RaycastHit rayHit;
	private Ray ray;
	

	// Use this for initialization
	void Start () {
		onCooldown = false;
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
				GameObject spellInstance;
					
				//Set the rotation for the instantiated projectile based on mouse click
				Transform tempTran = warlock.transform;
				tempTran.LookAt(rayHit.point);
				warlock.transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
					
				//Instantitate an instance of the spell at the "wand" (shotOrigin) of the wizarrd object
				Vector3 startPosition = warlock.transform.FindChild("Body").FindChild("ShotOrigin").transform.position;
				spellInstance = Instantiate(spell, startPosition, warlock.transform.rotation) as GameObject;
				Vector3 endPosition = spellInstance.transform.TransformPoint(Vector3.forward * range);
				StartCoroutine(FireProjectile(spellInstance, startPosition, endPosition));
				StartCoroutine(TriggerCooldown());
			}
			return true;
		}
		else
			return false;
		
	}

	
	IEnumerator FireProjectile(GameObject projectile, Vector3 startPosition, Vector3 endPosition)
	{
		
		float percentDistance = 0f;
		float distance = Vector3.Distance(startPosition, endPosition);
		float speed = shootSpeed/distance;
		onCooldown = true;
		
				
		while (percentDistance < 1)
		{
			percentDistance = percentDistance + Time.deltaTime * speed;
			if (percentDistance > 1)
				percentDistance = 1;
			projectile.transform.position = Vector3.Lerp(startPosition, endPosition, percentDistance);
			yield return null;
		}
		Destroy(projectile);
		
	}
	
	IEnumerator TriggerCooldown()
	{
		yield return new WaitForSeconds(cooldown);
		onCooldown = false;
	}
	
}
 