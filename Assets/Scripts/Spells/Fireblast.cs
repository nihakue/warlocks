using UnityEngine;
using System.Collections;

public class Fireblast: MonoBehaviour {
	
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
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Cast(){
		if (!onCooldown)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayHit))
			{
				GameObject spellInstance;
					
				//Set the rotation for the instantiated projectile based on mouse click
				Transform tempTran = transform;
				tempTran.LookAt(rayHit.point);
				transform.rotation = Quaternion.Euler(0, tempTran.rotation.eulerAngles.y, 0);
					
				//Instantitate an instance of the spell at the "wand" (shotOrigin) of the wizarrd object
				Vector3 startPosition = transform.FindChild("Body").FindChild("ShotOrigin").transform.position;
				spellInstance = Instantiate(spell, startPosition, transform.rotation) as GameObject;
				Vector3 endPosition = spellInstance.transform.TransformPoint(Vector3.forward * range);
				StartCoroutine(FireProjectile(spellInstance, startPosition, endPosition));
				StartCoroutine(TriggerCooldown());
			}
		}
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
 