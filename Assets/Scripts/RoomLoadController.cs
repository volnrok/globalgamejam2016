using UnityEngine;
using System.Collections;

public class RoomLoadController : MonoBehaviour, IClickable {

	public string roomToLoad;
	public GameObject[] cursors;

	void Start () {
	
	}

	void Update () {
	
	}

	public void Activate () {
		Application.LoadLevel (roomToLoad);
	}
}
