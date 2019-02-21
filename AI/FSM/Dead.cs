using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace FSM
{
    /// <summary>
    /// 死亡
    /// </summary>
    public class Dead : FSMState
    {
        public Dead(AIController aiCtrl):base(aiCtrl)
        {
            actionID = FSMActionID.Dead;
        }
        public override void Reason(List<Transform> targets, Transform npc)
        {
           
        }
        public override void Act(List<Transform> targets, Transform actor)
        {
            GameObject deadDisplace = actor.GetComponent<AIController>().deadDispLace;
            GameObject.Instantiate(deadDisplace,actor.position,actor.rotation);
        }
    }
}
