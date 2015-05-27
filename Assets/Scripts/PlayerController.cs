using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text scoreUI;
	public Text messageUI;

	private Rigidbody Rigidbody;
	protected int _score;
	private int score
	{
		get
		{
			return this._score;
		}

		set
		{
			this._score = value;
			this.UpdateScoreUI();
			if (this.countPickUps() <= 0)
			{
				this.messageUI.text = "You win!";
			}
		}
	}

	void Start ()
	{
		this.Rigidbody = GetComponent<UnityEngine.Rigidbody>();
		this.score = 0;
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
			this.CollectPickUp (other.gameObject);
		}
	}

	void CollectPickUp (GameObject PickUp)
	{
		PickUp.SetActive (false);
		Destroy (PickUp);
		this.score += 1;
	}

	void UpdateScoreUI ()
	{
		this.scoreUI.text = string.Format("Score: {0}", this.score);
	}

	int countPickUps ()
	{
		return GameObject.FindGameObjectsWithTag("PickUp").Length;
	}
}
