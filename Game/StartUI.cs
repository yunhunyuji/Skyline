using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour {
	public ParticleSystem logoParticle;
	public GameObject logo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			logoParticle.Play();
			logo.SetActive(false);
			Invoke("LoadSence",4);

		}
	}
	void LoadSence(){

			SceneManager.LoadScene("bigmap");
	}
}
