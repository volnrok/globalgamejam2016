using UnityEngine;
using System.Collections;

public class DruidHairController : MonoBehaviour {

	private SpriteRenderer sr;
	private Sprite hairNeat;
	private Sprite hairWild;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		hairNeat = Resources.Load<Sprite> ("Druid/druidHairNeat");
		hairWild = Resources.Load<Sprite> ("Druid/druidHairWild");
	}

	void Update () {
		if (Manager.game.isHairBrushed) {
			sr.sprite = hairNeat;
		} else {
			sr.sprite = hairWild;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Hairbrush") {
			Manager.game.isHairBrushed = true;
		}
	}
}
