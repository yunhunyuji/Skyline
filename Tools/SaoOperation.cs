using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
public class SaoOperation:MonoBehaviour {

	// Use this for initialization
	#if UNITY_EDITOR
	[MenuItem("Tools/删除MeshCollider",false,100)]
	public static void SaoOperate () {
		Transform[] listTile = Selection.GetTransforms(SelectionMode.TopLevel);
		foreach(Transform t in listTile){
			MeshCollider mc = t.GetComponent<MeshCollider>();
			if(mc != null){
				DestroyImmediate(mc);
			}
			t.gameObject.AddComponent<MeshCollider>();
		}
	}
	#endif

}
