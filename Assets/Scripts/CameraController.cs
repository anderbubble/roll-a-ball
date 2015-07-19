using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		//this.transform.LookAt (this.player.);
		//offset = this.transform.position - this.player.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		this.transform.LookAt (this.player);
		//this.transform.position = this.player.position + offset;
	}
}
