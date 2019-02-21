using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace FSM
{
    public class Attack : FSMState
    {
     
        public Attack(AIController aiCtrl):base(aiCtrl)
        {
            actionID = FSMActionID.Attacking;
            curRotSpeed = 12;
            curSpeed = 100;
            //FindNextPoint();//指定攻击对象
        }
        public override void Reason(List<Transform> player, Transform actor)
        {
            bool isNear = false;
            foreach(Transform t in player){
                float dist = Vector3.Distance(actor.position, t.position);
                if (dist >= attackDistance && dist < chaseDistance)
                {
                    Debug.Log("发现玩家");
                    actor.GetComponent<AIController>().SetTransition(Transition.SawPlayer);
                    break;
                }
                else if (dist >= chaseDistance)
                {
                    Debug.Log("丢失玩家");
                    actor.GetComponent<AIController>().SetTransition(Transition.LostPlayer);
                    break;
                }

                
            }
        }
        public override void Act(List<Transform> targets, Transform actor)
        {
            if (targets == null || targets.Count == 0) return;

            //旋转方向
            Quaternion targetRotation = Quaternion.LookRotation(destPos - actor.position);
            actor.rotation = Quaternion.Slerp(actor.rotation, targetRotation, Time.deltaTime * curRotSpeed);

            //播放动画
            aiCtrl.Attack();
            p.delhp(1);
            Debug.Log("造成伤害");
        }
    }
}
