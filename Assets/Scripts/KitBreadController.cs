using UnityEngine;
using System.Collections;

public class KitBreadController : MonoBehaviour {

	private SpriteRenderer sr;
	private Sprite breadCut;
	private Sprite breadToast;
	private Sprite breadJam;
	private InteractableItemController item;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		breadCut = Resources.Load<Sprite> ("Bread/bread");
		breadToast = Resources.Load<Sprite> ("Bread/toast");
		breadJam = Resources.Load<Sprite> ("Bread/toastJam");
		item = GetComponent<InteractableItemController> ();
	}

	void Update () {
		if (Manager.game.kitBreadState == Manager.BreadState.Cut) {
			sr.sprite = breadCut;
			setVisible (true);
		} else if (Manager.game.kitBreadState == Manager.BreadState.Toast) {
			sr.sprite = breadToast;
			setVisible (true);
		} else if (Manager.game.kitBreadState == Manager.BreadState.Jam) {
			sr.sprite = breadJam;
			setVisible (true);
		} else {
			setVisible(false);
		}
	}

	private void setVisible(bool visible) {
		if (visible) {
			item.isSelectable = true;
			sr.color = Color.white;
		} else {
			item.isSelectable = false;
			item.isHeld = false;
			sr.color = Color.clear;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "JamKnife" && Manager.game.kitIsJamOnKnife && Manager.game.kitBreadState == Manager.BreadState.Toast) {
			Manager.game.kitIsJamOnKnife = false;
			Manager.game.kitBreadState = Manager.BreadState.Jam;
		}
	}
}
