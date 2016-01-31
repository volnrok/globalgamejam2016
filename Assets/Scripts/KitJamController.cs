using UnityEngine;
using System.Collections;

public class KitJamController : MonoBehaviour {

	private SpriteRenderer sr;
	private Sprite jamClosed;
	private Sprite jamOpen;
	private InteractableItemController item;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		jamClosed = Resources.Load<Sprite> ("Bread/jam");
		jamOpen = Resources.Load<Sprite> ("Bread/jamOpen");
		item = GetComponent<InteractableItemController> ();
	}

	void Update () {
		if (item.isHeld) {
			if (!Manager.game.kitIsJamOpen && (item.cursorDirection == Manager.Dir.Up ||
			                                   item.cursorDirection == Manager.Dir.Left ||
			                                   item.cursorDirection == Manager.Dir.Right)) {
				Manager.game.kitIsJamOpen = true;
			}
		}
		if (Manager.game.kitIsJamOpen) {
			sr.sprite = jamOpen;
		} else {
			sr.sprite = jamClosed;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "JamKnife" && Manager.game.kitIsJamOpen && !Manager.game.kitIsJamOnKnife) {
			Manager.game.kitIsJamOnKnife = true;
		}
	}
}
