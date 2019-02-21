using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class mapmove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        creatplayer();
       for(int i=0;i<pointgroups.Count;i++)
        {
            if(nowpointid==pointgroups[i].pointid)
            {
                player.transform.position = pointgroups[i].transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        getpoint();
    }

    public Camera mapcamera;
    public GameObject player;
    private float movespeed = 3;
    public List<point_base> pointgroups;
    public int nowpointid=0;
    private GameObject nowpoint;

    public void getpoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mapcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitobj = hit.collider.gameObject;
                if(hitobj.tag=="point")
                {
                    //if(checkpoint(hitobj.GetComponent<point_base>().pointid))
                    movetopoint(hitobj);
                }
            }
        }
    }
    public void movetopoint(GameObject actor)
    {   /*
        *用dotween处理行走路径 后期考虑进行结点化处理
        */
        player.transform.DOMove(actor.transform.position, 1);
    }
    public bool checkpoint(int gopoint)
    {
        if (gopoint-nowpointid==1)
        {
            nowpointid = gopoint;
            return true;
        }
        else
        {
            Debug.Log("小于现在id");
            return false;
        }
    }
    /// <summary>
    /// 初始化角色位置
    /// </summary>
    public void creatplayer()
    {

        int n_point = PlayerPrefs.GetInt("pointid");
       

    }
}
