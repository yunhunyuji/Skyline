using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  choose_ctr : MonoBehaviour {

    private choose_ctr _instance;
    public choose_ctr Instance
    {
        get
        {
            if (_instance == null)
                _instance = new choose_ctr();
            return _instance;

        }
    }
    public Camera m_camera;
   
    private RaycastHit hitobj;
    private GameObject nowhit;
   // public floormanager f_manager;
    public GameObject getobjbyray()
    {

        if(Input.GetMouseButton(0))
        {
            Ray mray = m_camera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(mray,out hitobj))
            {
                if(hitobj.transform.tag=="tile")
                {
                    nowhit = hitobj.collider.gameObject;
             //       int x = nowhit.gameObject.GetComponent<floorbase>().landid / 10;
               //     int y = nowhit.gameObject.GetComponent<floorbase>().landid % 10;
               //     Debug.Log(y);
              //      floormanager.showland(x-1, y-1);
              //      f_manager.gotoland(x - 1, y - 1);


                }
            }
            return nowhit;
        }
        return null;
    }
    public void Update()
    {
        getobjbyray();
    }

}
