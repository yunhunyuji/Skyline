using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Camera camera;
	
	void Awake()
	{
		if(camera == null)
			camera = Camera.main;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform.position);	
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Camera.main.transform.position - transform.position), 10 * Time.deltaTime);

	}
	public void Active(){
		gameObject.SetActive(true);

	}
	public void Frozen(){
		gameObject.SetActive(false);
	}
}
