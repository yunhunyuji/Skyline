using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ActionsManager : MonoBehaviour {

	public static ActionsManager Current;

	private List<Action> actionCalls = new List<Action>();

	public GameObject actionCircle; 	
	public Button[] Buttons;

	public ActionsManager()
	{
		Current = this;
	}
	void Awake()
	{
		actionCircle = GameObject.FindWithTag("ActionCircle");
		actionCircle.SetActive(false);
	}
	void Start () {
		for (int i = 0; i < Buttons.Length; i++) {
			var index = i;
			Buttons[index].onClick.AddListener(delegate() {
				OnButtonClick (index);
			});
		}

		ClearButtons ();
	}

	public void ClearButtons()
	{
		foreach(Button btn in Buttons){
			btn.gameObject.SetActive(false);
		}
		actionCalls.Clear ();
	}

	public void AddButton(Sprite pic, Action onClick)
	{
		int index = actionCalls.Count;
		Buttons[index].gameObject.SetActive (true);
		Buttons[index].transform.Find("Image").GetComponent<Image> ().sprite = pic;
		actionCalls.Add (onClick);
	}

	public void OnButtonClick (int index)
	{
		actionCalls [index] ();
	}


	// Use this for initialization
	public void ActiveActionCircle(Vector3 pos){
		actionCircle.SetActive(true);
		actionCircle.transform.position = pos + new Vector3(0,50,0);
	}
	public void ForzenActionCircle(){
		actionCircle.SetActive(false);
	}
}
