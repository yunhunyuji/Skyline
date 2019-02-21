using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorbase : MonoBehaviour {
    private bool isman = false;
    private Transform m_pos;
    public int landid;
   

    public void Start()
    {
        m_pos = this.gameObject.transform;
        
    }
    public Transform getpos()
    {
        return m_pos;
    }
    public bool checkisempty()
    {
        if (isman)
        {
            return true;
        }
        return false;
    }
    public void setman()
    {
        if(!checkisempty())
        isman = true;
    }
}
