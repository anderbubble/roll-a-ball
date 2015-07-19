﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public SpawnController playerSpawn;
	public List<SpawnController> PickupSpawn;
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
	Transform player;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.player = (Transform) this.playerSpawn.Spawn ();
		this.player.GetComponent<PlayerController>().GameController = this;
		this.player.GetComponent<PlayerController>().Camera = this.cameraController.GetComponent<Transform>();
		this.cameraController.player = this.player;
		this.SpawnPickUp ();
	}

	void SpawnPickUp()
	{
		Debug.Log ("spawn");
		if (this.PickupSpawn.Count > 0) {
			int spawnPointIndex = Mathf.FloorToInt(Random.value * this.PickupSpawn.Count);
			Debug.Log (spawnPointIndex);
			if (!this.PickupSpawn[spawnPointIndex].GetComponent<Collider>().bounds.Intersects (this.player.GetComponent<Collider>().bounds)) {
				this.PickupSpawn[spawnPointIndex].Spawn ();
			}
		}
	}

	public void Score () {
		this.score += 1;
	}

	void Update ()
	{
		if (this.countPickUps() < 1)
		{
			this.SpawnPickUp ();
		}
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
