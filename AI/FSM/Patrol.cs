using System;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FSM
{
    /// <summary>
    /// 巡逻
    /// </summary>
    public class Patrol : FSMState
    {
        float count = 0;
        /// <summary>
        /// 初始化
        /// </summary>
        public Patrol(AIController aiCtrl):base(aiCtrl)
        {
            actionID = FSMActionID.Patroling;
            curRotSpeed = 6;
            curSpeed = 80;
        }
        public override void Reason(List<Transform> targets, Transform actor)
        {
            foreach(Transform t in targets){
                if (Vector3.Distance(actor.position, t.position) <= chaseDistance)
                {
                    Debug.Log("转换为追逐状态");
                    actor.GetComponent<AIController>().SetTransition(Transition.SawPlayer);
                }
            }
        }
        public override void Act(List<Transform> targets, Transform actor)
        {
            count += Time.deltaTime;
 
            if (timer >= count) {
                Vector3 newPos = RandomNavSphere(actor.position, wanderRadius, -1);
                
                aiCtrl.Move(newPos);
                count = 0;
            }
            else{
                aiCtrl.SetIdle();
            }
        }

        public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
            Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
    
            randDirection += origin;
    
            NavMeshHit navHit;
    
            NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
            
            return navHit.position;
        }
    }
}
