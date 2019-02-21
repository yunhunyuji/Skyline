using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StandbyAction : ActionBehavior {

	void Awake()
	{
		ButtonPic = Resources.Load<Sprite>("Sprite/standby");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override Action GetClickAction(){
		return delegate() {
			Debug.Log("hehe");
		};
	}

}
