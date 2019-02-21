using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRagneDecal : MonoBehaviour {
	Transform tile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void SetTile(Transform tile){
		this.tile = tile;
		transform.position = tile.position/*  + new Vector3(0,0.6f,0)*/;
	}
}
