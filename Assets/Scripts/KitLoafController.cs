using UnityEngine;
using System.Collections;

public class KitLoafController : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Loaf?");
		if (other.tag == "BreadKnife" && Manager.game.kitBreadState == Manager.BreadState.None) {
			Debug.Log ("Yes");
			Manager.game.kitBreadState = Manager.BreadState.Cut;
		}
	}
}
