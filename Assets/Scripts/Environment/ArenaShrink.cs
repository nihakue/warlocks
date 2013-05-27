using UnityEngine;
using System.Collections;

public class ArenaShrink : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((transform.localScale.x * .9998f), transform.localScale.y, (transform.localScale.z * .9998f));
	
	}
}
