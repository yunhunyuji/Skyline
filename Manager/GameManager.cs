using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager Current;

	GameObject moveRangeDecal;
	GameObject moveCursor;
	// Use this for initialization
	public GameManager()
	{
		Current = this;
	}
	void Start () {
		moveRangeDecal = Resources.Load<GameObject>("Game/MoveRangeDecal");
		moveCursor = Resources.Load("Game/MoveCursor") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
