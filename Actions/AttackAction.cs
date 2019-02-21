using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackAction : ActionBehavior  {
	void Awake()
	{
		ButtonPic = Resources.Load<Sprite>("Sprite/fight");
	}
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
