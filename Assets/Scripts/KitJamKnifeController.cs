using UnityEngine;
using System.Collections;

public class KitJamKnifeController : MonoBehaviour {
	
	private SpriteRenderer sr;
	private Sprite knife;
	private Sprite jamKnife;
	
	void Start () {
		sr = GetComponentInParent<SpriteRenderer> ();
		knife = Resources.Load<Sprite> ("Bread/knife");
		jamKnife = Resources.Load<Sprite> ("Bread/jamKnife");
	}
	
	void Update () {
		if (Manager.game.kitIsJamOnKnife) {
			sr.sprite = jamKnife;
		} else {
			sr.sprite = knife;
		}
	}
}
