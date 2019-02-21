using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using FSM;
public class AIController : AdvanceFSM
{
    public string enemyTag;
    public GameObject deadDispLace;
    private NavMeshAgent agent;
    private Animator anim;
    public float wanderRadius;
    public float wanderTimer;
    
    public player_info p;
    public GameObject[] enemysGB;

    private int health;//健康值
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Initialize()
    {
        health = 100;
        elapseTime = 0;
        shootRate = 2;
        //初始化玩家角色
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator>();
        foreach(GameObject gb in enemysGB){
            enemys.Add(gb.transform);
        }
        if (enemys.Count == 0)
        {
            Debug.Log("没有敌人");
        }
        //初始化状态机
        ConstructFSM();

    }
    protected override void FSMUpdate()
    {
        elapseTime += Time.deltaTime;
    }
    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(enemys, transform);
        CurrentState.Act(enemys, transform);
    }
    /// <summary>
    /// 状态机初始化
    /// </summary>
    private void ConstructFSM()
    {

        //针对每一个行为进行初始化, 针对于每个行为进行状态到行为转变的添加
        //巡逻
        Patrol patrol = new Patrol(this);
        patrol.AddTransition(Transition.SawPlayer, FSMActionID.Chasing);
        patrol.AddTransition(Transition.NoHealth, FSMActionID.Dead);
        //追逐
        Chase chase = new Chase(this);
        chase.AddTransition(Transition.ReachPalyer, FSMActionID.Attacking);
        chase.AddTransition(Transition.LostPlayer, FSMActionID.Patroling);
        chase.AddTransition(Transition.NoHealth, FSMActionID.Dead);
        //攻击
        Attack attack = new Attack(this);
        attack.AddTransition(Transition.SawPlayer, FSMActionID.Chasing);
        attack.AddTransition(Transition.LostPlayer, FSMActionID.Patroling);
        attack.AddTransition(Transition.NoHealth, FSMActionID.Dead);
        //死亡
        Dead dead = new Dead(this);
        dead.AddTransition(Transition.NoHealth, FSMActionID.Dead);
        //把状态列表进行初始化
        AddFSMState(patrol);
        AddFSMState(chase);
        AddFSMState(attack);
        AddFSMState(dead);
    }
    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="transition"></param>
    public void SetTransition(Transition transition)
    {
        PerformTransition(transition);
    }
   /// <summary>
   /// 射击
   /// TODO
   /// </summary>
    public void Attack()
    {
        anim.SetBool("Run",false);
        anim.SetTrigger("Attack");
    }
    public void Move(Vector3 Des){
        agent.SetDestination(Des);
        
        anim.SetBool("Run",true);
    }
    public void SetIdle(){

        anim.SetBool("Run",false);
    }
}
