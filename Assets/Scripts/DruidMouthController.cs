using UnityEngine;
using System.Collections;

public class DruidMouthController : MonoBehaviour {

	private SpriteRenderer sr;
	private Sprite mouthSad;
	private Sprite mouthHappy;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		mouthSad = Resources.Load<Sprite> ("Druid/druidmouthSad");
		mouthHappy = Resources.Load<Sprite> ("Druid/druidmouthHappy");
	}

	void Update () {
		if (Manager.game.isTeethBrushed) {
			sr.sprite = mouthHappy;
		} else {
			sr.sprite = mouthSad;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Toothbrush") {
			Manager.game.isTeethBrushed = true;
		} else if (other.tag == "Bread" && Manager.game.kitBreadState == Manager.BreadState.Jam) {
			Manager.game.kitToastsEaten += 1;
			Manager.game.kitBreadState = Manager.BreadState.None;
		}
	}
}
