using UnityEngine;
using System.Collections;

public class KitToasterController : MonoBehaviour {

	private SpriteRenderer sr;
	private Sprite toaster;
	private Sprite toasterBread;
	private Sprite toasterDown;
	private Sprite toasterToast;
	private InteractableItemController item;

	void Start () {
		sr = GetComponentInParent<SpriteRenderer> ();
		toaster = Resources.Load<Sprite> ("Bread/toaster");
		toasterBread = Resources.Load<Sprite> ("Bread/toasterBread");
		toasterDown = Resources.Load<Sprite> ("Bread/toasterDown");
		toasterToast = Resources.Load<Sprite> ("Bread/toasterToast");
		item = GetComponentInParent<InteractableItemController> ();
	}

	void Update () {
		if (item.isHeld) {
			if (Manager.game.kitBreadState == Manager.BreadState.InToaster && item.cursorDirection == Manager.Dir.Down) {
				Manager.game.kitBreadState = Manager.BreadState.DownToast;
			} else if (Manager.game.kitBreadState == Manager.BreadState.DownToast && item.cursorDirection == Manager.Dir.Up) {
				Manager.game.kitBreadState = Manager.BreadState.UpToast;
			} else if (Manager.game.kitBreadState == Manager.BreadState.UpToast && item.cursorDirection == Manager.Dir.Left) {
				Manager.game.kitBreadState = Manager.BreadState.Toast;
			}
		}

		if (Manager.game.kitBreadState == Manager.BreadState.InToaster) {
			sr.sprite = toasterBread;
		} else if (Manager.game.kitBreadState == Manager.BreadState.DownToast) {
			sr.sprite = toasterDown;
		} else if (Manager.game.kitBreadState == Manager.BreadState.UpToast) {
			sr.sprite = toasterToast;
		} else {
			sr.sprite = toaster;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bread" && Manager.game.kitBreadState == Manager.BreadState.Cut) {
			Manager.game.kitBreadState = Manager.BreadState.InToaster;
		}
	}
}
