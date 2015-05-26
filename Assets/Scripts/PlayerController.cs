using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float Thrust;
	Rigidbody Rigidbody;

	public float speed;

	void Start ()
	{
		this.Rigidbody = GetComponent<UnityEngine.Rigidbody>();
	}

	void FixedUpdate ()
	{
		var horizontal = Input.GetAxis ("Horizontal");
		var vertical = Input.GetAxis ("Vertical");
		var movement = new Vector3(horizontal, 0, vertical);

		this.Rigidbody.AddForce(speed * movement);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp")
		{
			Destroy (other.gameObject);
		}
	}
}
