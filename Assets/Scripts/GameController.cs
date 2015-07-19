using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public SpawnController playerSpawn;
	public SpawnController pickupSpawn;
	public CameraController cameraController;
	public Text scoreUI;
	public Text messageUI;
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
			if (this.score >= 10)
			{
				this.messageUI.text = "You win!";
			}
		}
	}

	// Use this for initialization
	void Start () {
		this.score = 0;
		Transform player = (Transform) this.playerSpawn.Spawn ();
		this.cameraController.player = player;

		Transform pickup = (Transform) this.pickupSpawn.Spawn ();
	}

	public void Score () {
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
