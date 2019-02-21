using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class cardmanager : MonoBehaviour {

    /*
     * 
     * 控制手牌，卡组
     *
     */

    public static GameObject cardprefab;//卡牌预制体
    public List<Sprite> cardimg;//卡牌卡池
    public List<Transform> handcard;//用来记录手牌位置
    public List<cardbase> groupcard;//卡组
    public player_info player;
    public Animator p_anima;
    private int myhandcard=0;  //手牌数量
    private int maxgroup; //卡组总数
    #region 生命周期 

    private static cardmanager _instacne;
    public static cardmanager Instacne
    {
        get
        {
            return _instacne;
        }
    }
    public void Start()
    {//临时用来生成卡组卡池
        List<int> a = new List<int>();
        a.Add(1001);
        a.Add(1001);
        a.Add(1001);
        a.Add(1002);
        a.Add(1003);
        a.Add(1004);
        a.Add(1005);
        creatgroup(a);
    }
    public void Update()
    {
        choosecard();
        selectactor();
    }
    #endregion

    #region 牌库相关
    /// <summary>
    /// 通过id增加卡牌到牌库
    /// </summary>
    public void addgropup(int id)
    {
        cardbase cb = new cardbase();
        if (id == 1001)
        {
            cb.card_id = 1001;
            cb.card_name = "攻击";
            cb.card_type = cardtype.attack;
            cb.card_cost = 1;
            cb.card_num = 3;
            groupcard.Add(cb);
            return;
        }
        if (id == 1002)
        {
            cb.card_id = 1002;
            cb.card_name = "防御";
            cb.card_type = cardtype.defence;
            cb.card_cost = 1;
            cb.card_num = 2;
            groupcard.Add(cb);
            return;
        }
        if (id == 1003)
        {
            cb.card_id = 1003;
            cb.card_name = "回避";
            cb.card_type = cardtype.evade;
            cb.card_cost = 2;
            cb.card_num = 1;
            groupcard.Add(cb);
            return;
        }
        if (id == 1004)
        {
            cb.card_id = 1004;
            cb.card_name = "巨力重击";
            cb.card_type = cardtype.skill;
            cb.card_cost = 3;
            cb.card_num = 15;
            groupcard.Add(cb);
            return;
        }
        if (id == 1005)
        {
            cb.card_id = 1005;
            cb.card_name = "治疗";
            cb.card_type = cardtype.skill;
            cb.card_cost = 1;
            cb.card_num = 5;
            groupcard.Add(cb);
            return;
        }
    }
    /// <summary>
    ///通过id删除在牌库里的卡牌 
    /// </summary>
    public void delgroup(int id)
    {
        for(int i=0;i<groupcard.Count;i++)
        {
            if(groupcard[i].card_id==id)
            {
                groupcard.Remove(groupcard[i]);
                return;
            }
        }
    }
    /// <summary>
    /// 获得一个随机cardbase
    /// </summary>
    /// <returns></returns>
    public cardbase getcard()
    {
        cardbase c = new cardbase();
        int i = Random.Range(0, groupcard.Count);
        c = groupcard[i];
        return c;
    }
    /// <summary>
    /// 通过list初始化卡组
    /// </summary>
    /// <param name="group"></param>
    public void creatgroup(List<int>group)
    {
        for(int i=0;i<group.Count;i++)
        {
            addgropup(group[i]);
        }
    }
    #endregion

    #region 手牌相关
    /// <summary>
    /// 在手牌处生成卡牌(要调整卡牌位置)
    /// </summary>
    public void gocard()
    {
        if (myhandcard != 0)
            return;
        for (int j = 0; j < 4; j++) {
            Sprite temp = null;
            cardbase gobase = new cardbase();
            gobase = groupcard[Random.Range(0, groupcard.Count)];
            GameObject card = new GameObject();
            card.AddComponent<cardbase>();
            card.AddComponent<SpriteRenderer>();
            card.layer = 9;
            card.tag = "card";
            card.AddComponent<BoxCollider>();
            card.GetComponent<BoxCollider>().size = new Vector3(3.5f,5, 1);
            changecard(card.GetComponent<cardbase>(), gobase);
            for (int i = 0; i < cardimg.Count; i++)
            {
                if (gobase.card_id.ToString() == cardimg[i].name)
                {
                    temp = cardimg[i];
                }
            }
            card.GetComponent<SpriteRenderer>().sprite = temp;
            //Instantiate(card);
            card.transform.position = handcard[j].position;
            card.transform.SetParent(handcard[j]);
        }
        myhandcard = 4;
        
    }
    public void changecard(cardbase a,cardbase b)
    {
        a.card_cost = b.card_cost;
        a.card_id = b.card_id;
        a.card_name = b.card_name;
        a.card_type = b.card_type;
        a.card_num = b.card_num;
    }
    public void usecard()
    {//使用卡牌
        if (myhandcard == 0)
            return;
        if (selectcard == null)
            return;
        if (selactor == null)
            return;
        int useid = selectcard.GetComponent<cardbase>().card_id;
        if(useid==1001)
        {          
                myhandcard--;
            s_attack(selactor.GetComponent<monster_info>(),3);
            Destroy(selectcard);
            selectcard = null;
        }
        if (useid == 1002)
        {
                myhandcard--;
            s_defend(player,2);
            Destroy(selectcard);
            selectcard = null;
        }
        if (useid == 1003)
        {
                myhandcard--;
            avoid(player);
            Destroy(selectcard);
            selectcard = null;
        }
        if (useid == 1004)
        {
                myhandcard--;
            s_heavyattack(selactor.GetComponent<monster_info>(),15);
            Destroy(selectcard);
            selectcard = null;
        }
        if (useid == 1005)
        {          
                myhandcard--;
            s_heal(player,3);
            Destroy(selectcard);
            selectcard = null;
        }

    }
    /// <summary>
    /// 移除手牌
    /// </summary>
    public void removehandcard(GameObject a)
    {

    }
    /// <summary>
    /// 抽卡
    /// </summary>
    public void setcard()
    {
        if (myhandcard == 0)
        {
            gocard();
       }
    }
    #endregion

    #region 卡牌选择控制
    public Camera card_camera;
    private RaycastHit hitobj;
    private GameObject selectcard;
     public void choosecard()
    {
        if(Input.GetMouseButton(0))
        {
            Ray mray = card_camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mray, out hitobj))
            {
                if (hitobj.transform.tag == "card")
                {//获取了选中的卡牌
                    selectcard = hitobj.collider.gameObject;
                    //展示卡牌信息 showcard(slectcard)
                    Debug.Log("选中了卡牌" + selectcard.GetComponent<cardbase>().card_name);
                }
            }

        }
    }
    /// <summary>
    /// 展示卡牌信息
    /// </summary>
    /// <param name="a"></param>
    public void showcard(cardbase a)
    {

    }

    #endregion

    #region 技能逻辑
 
    public void s_attack(monster_info actor,int addnum)//攻击
    {
        if (player.delendurance(1))
        actor.delhp(player.Attack+addnum);
        p_anima.SetTrigger("DownAtk");
       
    }
    public void s_defend(player_info player,int addnum)//防御
    {
        if (player.delendurance(2)) 
            player.adddefence(addnum);
        p_anima.SetTrigger("HorAtk");
    }
    public void s_heal(player_info player,int addnum)//加血
    {
        if (player.delendurance(3))
            if (player.Health <= player.Maxhp)
        {
            int num = player.Maxhp - addnum;
            player.addhp(num);
        }
       
    }
    public void s_heavyattack(monster_info actor,int num)//重击
    {
        if (player.delendurance(3))
            actor.delhp(player.Attack+ num);
            p_anima.SetTrigger("ComAtk");
    }
    public void avoid(player_info player )//回避
    {
        if (player.delendurance(2))
            player.Isavoid = true;
     
    }
    #endregion

    #region 敌人选择控制
    public Camera main_camera;//主摄像机
    private RaycastHit actorhit;
    private GameObject selactor;//选择的目标
    public void selectactor()
    {
        if(Input.GetMouseButton(0))
        {
            Ray mray = main_camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(mray, out actorhit))
            {
                if (actorhit.transform.tag == "enemy")
                {//获取了选中的卡牌
                    selactor = actorhit.collider.gameObject;
                    Debug.Log("选中了怪兽");
                    player.gameObject.transform.LookAt(selactor.transform);
                }
            }
        }

    }
    #endregion
}






