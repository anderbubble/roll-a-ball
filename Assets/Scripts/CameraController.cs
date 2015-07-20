using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Transform player;
	public int speed = 10;
	private Vector3 offset;
	
	
	void FixedUpdate ()
	{
		var horizontal = Input.GetAxis ("CameraHorizontal");
		var vertical = Input.GetAxis ("CameraVertical");
		var movement = new Vector3(horizontal, 0, vertical);
		
		this.GetComponent<Rigidbody>().AddForce(speed * movement);
	}

	void LateUpdate ()
	{
		this.transform.LookAt (this.player);
	}
}
