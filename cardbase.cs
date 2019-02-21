using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cardbase: MonoBehaviour  {
    /*
     *卡牌基础功能 
     * 
     */
    public int card_id;
    public string card_name;
    public cardtype card_type;
    public int card_cost;
    
    /// <summary>
    /// 卡牌数值
    /// </summary>
    public int card_num;
    //public int cardpic
    //public string introduce
}
public enum cardtype
    {
        attack,
        defence,
        evade,
        skill
    }

