using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableItemController : MonoBehaviour {

	public bool isFixed = true;
	public bool isHeld = false;
	public bool isSelectable = true;
	public string playerid = "";
	public Manager.Dir cursorDirection = Manager.Dir.None;

	private Vector3 startPosition;
	private SpriteRenderer sr;

	void Start () {
		startPosition = transform.position;
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		cursorDirection = Manager.Dir.None;
		if (isHeld) {
			if (playerid != "") {
				float horiz = Input.GetAxis ("Horizontal" + playerid);
				float vert = Input.GetAxis ("Vertical" + playerid);

				if (-0.3 < vert && vert < 0.3) {
					if (horiz > 0.5) {
						cursorDirection = Manager.Dir.Right;
					} else if (horiz < -0.5) {
						cursorDirection = Manager.Dir.Left;
					}
				} else if (-0.3 < horiz && horiz < 0.3) {
					if (vert > 0.5) {
						cursorDirection = Manager.Dir.Up;
					} else if (vert < -0.5) {
						cursorDirection = Manager.Dir.Down;
					}
				}
			}
		}
	}
	
	public void ReleaseItem () {
		playerid = "";
		transform.position = startPosition;
		isHeld = false;
		sr.sortingLayerName = "Default";
	}
	
	public void SelectItem (string id) {
		playerid = id;
		isHeld = true;
		sr.sortingLayerName = "PickedUp";

		foreach (IClickable clickable in GetComponentsInChildren<IClickable> ()) {
			clickable.Activate();
		}
	}
}
