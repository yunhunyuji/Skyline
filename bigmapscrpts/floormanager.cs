using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floormanager : MonoBehaviour
{

    private floormanager _instance;
    public floormanager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new floormanager();
            return _instance;

        }
    }
    public static GameObject player;
    public List<GameObject> landlist = new List<GameObject>();
    public static GameObject[,] mapland = new GameObject[6, 8];
    
    public void setmapland()
    {///将地图格子放入二维数组
        for (int j = 0; j <6; j++)
        {
            for (int k = 0; k <8; k++)
            {
                for (int i = 0; i < landlist.Count; i++)
                {
                    if (landlist[i].GetComponent<floorbase>().landid == ((j+1) * 10 + k+1))
                    {
                        mapland[j, k] = landlist[i];
                        i = 0;
                        //Debug.Log(mapland[j, k].gameObject.GetComponent<floorbase>().landid);
                        break;
                    }
                }

            }
        }
    }
    public  void gotoland(int i,int j)
    {
        ///加个是否能到达判断
        if (canmove(i*10+j)) {
 Vector3 newV = new Vector3(mapland[i, j].transform.position.x, mapland[i, j].transform.position.y+1, mapland[i, j].transform.position.z);
        player.transform.position = newV;
            return; }

       
    }
    public static void  showland(int i,int j)
    {
        Debug.Log(mapland[i, j].gameObject.GetComponent<floorbase>().landid);
    }
    public void Start()
    {
        setmapland();
        
    }
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    #region 最短路径工厂
    /*
     *LCS数组用来计算最短路径，通过传入两个坐标返回得到一条路径 
     */
    public static int[,] lcs_map = new int[6, 8];//二维数组结构定义：0->空地，1->障碍物,2->角色
    public void creatlcs()
    {
       for(int i=0;i<6;i++)
        {
            for (int j=0;j<8;j++)
            {
                lcs_map[i, j] = 0;
            }
        }
    }
    /// <summary>
    /// 传入坐标位置，类型改变Lcs
    /// </summary>
    /// <param name="po"></param>
    /// <param name="type"></param>
    public void changelcs(int po,int type)
    {
        lcs_map[dox(po), doy(po)] = type;
    }
    /// <summary>
    /// 传入开始坐标和到达坐标返回一个list
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
   /* 
    * public static List<int> gotoactor(int start,int end)
    {
        List<int> movelist = new List<int>();
        if(dox(start)>dox(end))
        {
            int[,] point1 = { };
        }
        return movelist;
    }*/
    
    private static int dox(int po)//计算x值
    {
        int x = po / 10;
        return x;
    }
    private static int doy(int po)//计算y值
    {
        int y = po % 10;
        return y;
    }
    private static int dopoint(int x,int y)//计算点值
    {
        int gopoint = x * 10 + y;
        return gopoint;
    }
     List<int> canmovelist=new List<int>();
    private  List<int> movepoint(int start)
    {
        int x = dox(start);
        int y = dox(start);
        canmovelist.Clear();
        if (lcs_map[x-1,y]==0)
        {
            int point1 = dopoint(x - 1, y);
            canmovelist.Add(point1);
        }
        if(lcs_map[x,y+1]==0)
        {
            int point2 = dopoint(x, y + 1);
            canmovelist.Add(point2);
        }
        if(lcs_map[x+1,y+1]==0)
        {
            int point3 = dopoint(x + 1, y + 1);
            canmovelist.Add(point3);
        }
        if(lcs_map[x+1,y]==0)
        {
            int point4 = dopoint(x + 1, y);
            canmovelist.Add(point4);
        }
        if (lcs_map[x + 1, y-1] == 0)
        {
            int point5 = dopoint(x + 1, y-1);
            canmovelist.Add(point5);
        }
        if (lcs_map[x , y-1] == 0)
        {
            int point6 = dopoint(x , y-1);
            canmovelist.Add(point6);
        }
       
        return canmovelist;
    }
    public  bool canmove(int topoint)
    {
        List<int> dolist = new List<int>();
        dolist = movepoint(player.GetComponent<player_info>().Nowpoint);
        for(int i = 0; i < dolist.Count; i++)
        {
            if(dolist[i]==topoint)
            {
                player.GetComponent<player_info>().Nowpoint = topoint;
                return true;
            }
        }
        return false;
    }
    #endregion
}

