using UnityEngine;
using System.Collections;

public static class Manager {
	public static GameState game = new GameState ();
	
	public enum BreadState {None, Cut, InToaster, DownToast, UpToast, Toast, Jam};

	public static readonly float HORIZ_EDGE = 3.2f;
	public static readonly float VERT_EDGE = 2.4f;

	public enum Dir {None, Up, Down, Left, Right};
}

public class GameState {
	public bool isHairBrushed = false;
	public bool isTeethBrushed = false;
	
	public Manager.BreadState kitBreadState = Manager.BreadState.None;
	public bool kitIsJamOpen = false;
	public bool kitIsJamOnKnife = false;
	public int kitToastsEaten = 0;
}
