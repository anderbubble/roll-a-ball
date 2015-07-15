using UnityEngine;
using System.Collections;

public class PickupManager: MonoBehaviour {

	public Transform pickupTemplate;

	// Use this for initialization
	void Start () {
		Instantiate(this.pickupTemplate, new Vector3(-5, 1, -5), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
