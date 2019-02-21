using UnityEngine;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour {

	public static MouseManager Current;

	public MouseManager()
	{
		Current = this;
	}


	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButtonDown (0)){
			return;
		}

		var es = UnityEngine.EventSystems.EventSystem.current;
		if (es != null && es.IsPointerOverGameObject ()){
			return;
		}


		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (!Physics.Raycast (ray, out hit) || !hit.transform.tag.Equals("Character")){
			ActionsManager.Current.ForzenActionCircle();
			return;
		}

		var interact = hit.transform.GetComponent<Interactive> ();
		if (interact == null)
			return;
		ActionsManager.Current.ActiveActionCircle(Camera.main.WorldToScreenPoint(hit.transform.position));
		interact.Select ();
	}
}
