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
			Quaternion.AngleAxis(Time.deltaTime * this.speed * Input.GetAxis ("Mouse X"), Vector3.up)
				* this.offset;
		this.offset =
			Quaternion.AngleAxis (Time.deltaTime * this.speed * Input.GetAxis ("Mouse Y"), Vector3.Cross (this.offset, Vector3.up))
				* this.offset;
		this.transform.position = target.position - this.offset;
		this.transform.LookAt(target);
	}
}
