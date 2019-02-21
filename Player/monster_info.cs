using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monster_info : MonoBehaviour {


    #region 怪物属性定义
    private int health;
    private int attack;
    private int defence;
    public int Health
    {
        set
        {
            health = value;
        }
        get
        {
            return health;
        }
    }
    public int Attack
    {
        set
        {
            attack = value;
        }
        get
        {
            return attack;
        }
    }
    public int Defence
    {
        set
        {
            defence = value;
        }
        get
        {
            return defence;
        }
    }
    #endregion

    #region 怪物初始化
    private Transform monsterpos;
    public GameObject monster;
    public void creatmonster(int hp,int atk,int def)
    {
        Health = hp;
        Attack = atk;
        Defence = def;
    }
    /// <summary>
    /// 在地图中生成怪物
    /// </summary>
    public void insmonster()
    {   
        Instantiate(monster);
        
    }
    #endregion

    #region 怪物数值控制
    public void delhp(int num)//怪物扣血
    {
        Health = Health - num + Defence;
        Debug.Log("当前怪物血量:" + Health);
    }
    #endregion

    #region 怪物生命周期

    private AIController ai_c;
    private void Start()
    {
        creatmonster(20, 5, 2);
        ai_c = gameObject.GetComponent<AIController>();
    }
    public void Update()
    {
        
        if(Health<0)
        {
            Debug.Log("怪物死亡");
            Instantiate(ai_c.deadDispLace, this.transform.position, transform.rotation);               
            Invoke("tomap", 5f);
            Destroy(this.gameObject);
        }
    }
    public void tomap()
    {
         SceneManager.LoadScene("bigmap");
    }
    #endregion

}
