using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class point_base : MonoBehaviour {

    public int pointid;
  //  public business_base business;
    public bool isenter=false;
    public bool isfinish=false;
    public int businessid;

    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
           if(pointid==11)
            {
                SceneManager.LoadScene("CityNavigation");
                PlayerPrefs.SetInt("pointid", 11);
            }
           if(pointid==12)
            {
                SceneManager.LoadScene("SampleScene");
                PlayerPrefs.SetInt("pointid", 12);
            }
        }
    }
    /// <summary>
    /// 使用相应地点的事件
    /// </summary>
    public void usebusiness()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {

        }
    }

}
