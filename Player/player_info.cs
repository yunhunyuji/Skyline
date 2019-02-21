using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_info : MonoBehaviour {

    #region 玩家角色信息
    /*
     * 临时用作角色信息存储
     */
    private  int health;     //生命
    private  int endurance;  //耐力
    private int attack;   //攻击力
    private int denfence;
    private  float movespeed; //移动速度
    private  int nowpoint=11;//玩家默认在11
    private int maxhp;//最大生命值
    private bool isdefence=false;//是否是防御状态
    private bool isavoid = false;//是否进入闪避
    private Playertype type;
    public enum Playertype //地图状态
    {
        bigmap,
        simplemap,
        fightmap
    }
    private gametype g_type;//游戏进行状态
    public enum gametype
    {
        nofight,
        fight,
        vectory,
        lose
    }
    #endregion

    #region 角色生命周期
   private void Start()
    {
        setchara();
        InvokeRepeating("get_en", 1,2.5f);//回复体力
        DontDestroyOnLoad(this.gameObject);    
    }
    private void testtime()
    {
        Debug.Log("执行一次");
    }
    public void Update()
    {
        
        
    }
    #endregion

    #region 信息封装
    public gametype G_type
    {
        get { return g_type; }
        set { g_type = value; }
    }
    public Playertype Type
    {
        get{return type; }
        set{ type = value;}        
    }
    public bool Isavoid
    {
        set { isavoid = value; }
    }
    public int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }
    public int Defence
    {
        get { return denfence; }
        set { denfence = value; }
    }
    public   int Nowpoint
    {
        get { return nowpoint; }
        set { nowpoint = value; }
    }
    public  int Health
    {
        get { return health; }
        set { health = value; }
    }
    public  int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }
    public  int Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    public  float Movespeed
    {
        get { return movespeed; }
        set { movespeed = value; }
    }

    
    #endregion

    #region 初始化角色信息
    private void setchara()
    {
        Health = 5;
        Endurance = 7;
        Attack = 10;
        movespeed = 6;
        Maxhp = 5;
        Defence = 1;
        Type = Playertype.bigmap;
    }
    
    #endregion

    #region 角色信息变化控制
    /// <summary>
    /// 增加角色生命
    /// </summary>
    public void addhp(int num)
    {
        Health += num;
    }
    /// <summary>
    /// 减少角色生命
    /// </summary>
    public void delhp(int num)
    {
        if(isavoid)
        {
            isavoid = false;
            return;
        }
        int delnum = num - Defence;
        if(delnum>0)
        {
            Health -= delnum;
        }
        if (isdefence == true)//如果处于防御状态回归
        {
            isdefence = false;
            Defence = 1;
        }
    }
    /// <summary>
    /// 增加角色耐力
    /// </summary>
   public void addendurance(int num)
    {
        if (Endurance < 7)
        {
            Endurance += num;
           
            return;
        }
        return;
    }
  
    /// <summary>
    /// 减少角色耐力
    /// </summary>
    public bool delendurance(int num)
    {
        if(Endurance>=num)
        {
            Endurance -= num;
            return true;
        }
        else
        {
            Debug.Log("耐力不足");
            return false;
        }
    }
    /// <summary>
    /// 增加攻击力
    /// </summary>
    public void addattack(int num)
    {
        Attack -= num;
    }
    public void rebackplayer()
    {
        Attack = 5;
        Endurance = 5;
        Defence = 1;
    }
    public void adddefence(int num)
    {
        denfence += num;
        isdefence = true;
    }
    public void deldefence(int num)
    {
        denfence -= num;
    }
    #endregion

    #region 角色逻辑控制
    /// <summary>
    /// 角色死亡
    /// </summary>
    public void playerdead()
    {
        if(Health<=0)
        {
            //控制角色死亡
        }
    }
    /// <summary>
    /// 使用耐力
    /// </summary>
    public void use_en(int cost)
    {
        if(Endurance>0)
        {
            delendurance(cost);
        }
    }
    public void get_en()
    {//当耐力不足时候恢复耐力用
        if(Endurance<7)
        {
            addendurance(1);
            Debug.Log("回复了耐力"+Endurance.ToString());
        }
    }

    #endregion

    #region 游戏状态控制
    #endregion
}
