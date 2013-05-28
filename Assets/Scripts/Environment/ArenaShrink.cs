using UnityEngine;
using System.Collections;

public class ArenaShrink : MonoBehaviour {
	
	public float shrinkRate;
	
	// Use this for initialization
	void Start () {
		shrinkRate = .9998f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((transform.localScale.x * shrinkRate), transform.localScale.y, (transform.localScale.z * shrinkRate));
	
	}
}
