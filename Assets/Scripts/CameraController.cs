using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform target;
	private Vector3 offset;
	public float speed = 180;

	void Start ()
	{
		this.offset = target.position - this.transform.position;
	}

	void LateUpdate ()
	{
		this.offset =
			Quaternion.AngleAxis(Time.deltaTime * this.speed * Input.GetAxis ("CameraHorizontal"), Vector3.up)
			* Quaternion.AngleAxis (Time.deltaTime * this.speed * Input.GetAxis ("CameraVertical"), Vector3.right)
			* this.offset;
		this.transform.position = target.position - this.offset;
		this.transform.LookAt(target);
	}
}
