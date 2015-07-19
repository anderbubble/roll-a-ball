using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	public GameController GameController;
	
	public void Collect ()
	{
		this.gameObject.SetActive (false);
		Destroy (this.gameObject);
		this.GameController.Score();
	}
}
