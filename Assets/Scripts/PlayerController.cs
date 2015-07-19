using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public GameController GameController;

	private Rigidbody Rigidbody;

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
			other.GetComponent<PickupController>().Collect();
		}
	}
}