using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

	public string playerid;
	public float moveSpeed;

	void Update () {
		float horiz = Input.GetAxis ("Horizontal" + playerid);
		float vert = Input.GetAxis ("Vertical" + playerid);

		transform.Translate (new Vector3 (horiz * moveSpeed, vert * moveSpeed, 0));
	}
}
