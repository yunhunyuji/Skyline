using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace FSM
{
    public class Chase : FSMState
    {
        public Chase(AIController aiCtrl) :base(aiCtrl)
        {

            actionID = FSMActionID.Chasing;

            curRotSpeed = 6;
            curSpeed = 160;

            //FindNextPoint();//追逐的目标
        }
        public override void Reason(List<Transform> player, Transform actor)
        {
            foreach(Transform t in player){
                float dist = Vector3.Distance(actor.position,destPos);
                if (dist <= attackDistance) 
                {
                    Debug.Log("转变到攻击状态");
                    actor.GetComponent<AIController>().SetTransition(Transition.ReachPalyer);
                    break;
                }
                else if(dist>=chaseDistance)
                {
                    Debug.Log("转变到巡逻状态");
                    actor.GetComponent<AIController>().SetTransition(Transition.LostPlayer);
                    break;
                }
            }
        }
        public override void Act(List<Transform> player, Transform actor)
        {
            float minDis = float.MaxValue;
            foreach(Transform t in player){
                float dis = Vector3.Distance(actor.position,t.position);
                if(dis < minDis){
                    minDis = dis;
                    destPos = t.position;
                }
            }

            //旋转方向
            Quaternion targetRotation = Quaternion.LookRotation(destPos-actor.position);
            actor.rotation = Quaternion.Slerp(actor.rotation,targetRotation,Time.deltaTime*curRotSpeed);

            //移动
            aiCtrl.Move(destPos);
        }
    }
}
