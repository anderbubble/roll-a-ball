using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Transform template;
	
	// Use this for initialization
	public Object Spawn () {
		Vector3 spawnPosition = this.GetComponent<Transform>().position;
		Vector3 prefabPosition = this.template.position;
		return Instantiate(this.template, spawnPosition + prefabPosition, Quaternion.identity);
	}
}
