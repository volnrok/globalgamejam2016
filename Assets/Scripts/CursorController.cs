using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorController : MonoBehaviour {

	public string playerid;
	public float moveSpeed;
	public Color inactiveColor;
	public Color activeColor;
	public Sprite fullCursor;
	public Sprite hollowCursor;

	private bool isLit = false;
	private SpriteRenderer sr;
	private GameObject heldObject = null;
	private InteractableItemController heldObjectItem;
	private List<GameObject> GOs = new List<GameObject> ();

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		float horiz = Input.GetAxis ("Horizontal" + playerid);
		float vert = Input.GetAxis ("Vertical" + playerid);

		transform.Translate (new Vector3 (horiz * moveSpeed, vert * moveSpeed, 0));

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -Manager.HORIZ_EDGE, Manager.HORIZ_EDGE),
		                                  Mathf.Clamp (transform.position.y, -Manager.VERT_EDGE, Manager.VERT_EDGE),
		                                  0);

		if (Input.GetButtonDown ("Hold" + playerid)) {
			if (isLit) {
				foreach (GameObject go in GOs) {
					InteractableItemController item = go.GetComponentInParent<InteractableItemController> ();
					if (item.isSelectable && !item.isHeld) {
						heldObject = item.gameObject;
						heldObjectItem = item;
						heldObjectItem.SelectItem (playerid);
					}
				}
			}
		}

		if (Input.GetButtonUp ("Hold" + playerid) || (heldObjectItem != null && !heldObjectItem.isHeld)) {
			if (heldObjectItem != null) {
				heldObjectItem.ReleaseItem ();
			}
			heldObject = null;
			heldObjectItem = null;
		}

		if (heldObject != null) {
			if (heldObjectItem.isFixed) {
				gameObject.transform.position = heldObject.transform.position;
			} else {
				heldObject.transform.position = gameObject.transform.position;
			}
		}

		if (isLit) {
			sr.color = activeColor;
		} else {
			sr.color = inactiveColor;
		}

		if (heldObject == null) {
			sr.sprite = hollowCursor;
		} else {
			sr.sprite = fullCursor;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		GOs.Add (other.gameObject);
		isLit = true;
	}

	void OnTriggerExit2D (Collider2D other) {
		GOs.Remove (other.gameObject);
		if (GOs.Count == 0) {
			isLit = false;
		}
	}
}
