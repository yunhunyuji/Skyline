using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

/// <summary>
/// FSM基类
/// </summary>
namespace FSM
{
    public abstract class FSMState
    {
        protected Dictionary<Transition, FSMActionID> map = new Dictionary<Transition, FSMActionID>();//存储转换过程
        protected AIController aiCtrl;
        //当前所处的行为
        protected FSMActionID actionID;
        
        public player_info p;
        public FSMActionID ID
        {
            get
            {
                return actionID;
            }
        }

        protected Vector3 destPos;//目标点

        protected float curRotSpeed;//旋转速度
        protected float curSpeed;//移动速度

        //距离限定
        protected float chaseDistance = 5;
        protected float attackDistance = 1;
        protected float arriveDistance = 3;
        public float timer;
        public float wanderRadius;
        public FSMState(AIController aiCtrl){
            this.aiCtrl = aiCtrl;
            this.timer = aiCtrl.wanderTimer;
            this.wanderRadius = aiCtrl.wanderRadius;
            this.p=aiCtrl.p;
        }

        /// <summary>
        /// 向字典中添加状态
        /// </summary>
        public void AddTransition(Transition trans, FSMActionID actionID)
        {
            //如果包含就停止
            if (map.ContainsKey(trans))
                return;
            map.Add(trans, actionID);
            Debug.Log("状态：" + trans + "添加成功");
        }
        /// <summary>
        /// 删除字典中指定的状态
        /// </summary>
        public void DeletTransition(Transition trans)
        {
            if (map.ContainsKey(trans))
            {
                map.Remove(trans);
                return;
            }
            Debug.Log("状态:" + trans + "不存在字典里");
        }
        public FSMActionID GetOutAction(Transition trans)
        {
            return map[trans];
        }
                
        //抽象状态转换的原因
        public abstract void Reason(List<Transform> player, Transform npc);
        //抽象转换的行为
        public abstract void Act(List<Transform> player, Transform npc);
    }
}
