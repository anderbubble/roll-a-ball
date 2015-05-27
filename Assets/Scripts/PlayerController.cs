using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text scoreUI;

	private Rigidbody Rigidbody;
	private int score;

	void Start ()
	{
		this.Rigidbody = GetComponent<UnityEngine.Rigidbody>();
		this.score = 0;
		this.UpdateScoreUI ();
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
			this.score += 1;
			this.UpdateScoreUI();
		}
	}

	void UpdateScoreUI ()
	{
		this.scoreUI.text = string.Format("Score: {0}", this.score);
	}
}
