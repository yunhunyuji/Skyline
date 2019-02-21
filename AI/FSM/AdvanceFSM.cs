using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;
using UnityEngine;
/// <summary>
/// 状态
/// </summary>
public enum Transition
{
    SawPlayer,//发现玩家
    ReachPalyer,//接近玩家
    LostPlayer,//丢失玩家
    NoHealth//没生命了
}
/// <summary>
/// 行为
/// </summary>
public enum FSMActionID
{
    Patroling,
    Chasing,
    Attacking,
    Dead
}
/// <summary>
/// 管理类
/// </summary>
public class AdvanceFSM : FSMBase
{
    private List<FSMState> fsmStates;//存储所有状态

    private FSMActionID currentActionID;//当前的行为ID
    public FSMActionID CurrentActionID
    {
        get
        {
            return currentActionID;
        }
    }
    private FSMState currentState;//当前的状态
    public FSMState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public AdvanceFSM()
    {
        fsmStates = new List<FSMState>();
    }
    /// <summary>
    /// 向列表中增加状态
    /// </summary>
    /// <param name="fsmState"></param>
    public void AddFSMState(FSMState fsmState)
    {
        if (fsmStates == null)
        {
            Debug.Log("新加入的状态为空");
          //  return;
        }
        //状态列表中什么都没有的时候
        if (fsmStates.Count == 0)
        {
            fsmStates.Add(fsmState);
            currentState = fsmState;
            currentActionID = fsmState.ID;
            return;
        }
        //要加入的状态是不是再列表中存在
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState.ID)
            {
                Debug.Log("状态已经存在");
                return;
            }
        }
        //如果不存在则加入状态
        fsmStates.Add(fsmState);
    }
    /// <summary>
    /// 删除列表中的状态
    /// </summary>
    public void DeleteState(FSMActionID fsmState)
    {
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState)
            {
                fsmStates.Remove(state);
                return;
            }
        }
        Debug.Log("当前列表中不存在这个状态");
    }
    /// <summary>
    /// 转变状态
    /// </summary>
    /// <param name="trans"></param>
    public void PerformTransition(Transition trans)
    {
        FSMActionID id = currentState.GetOutAction(trans);
        currentActionID = id;
        foreach (FSMState state in fsmStates) 
        {
            if (state.ID == currentActionID) 
            {
                currentState = state;
                break;
            }
        }
    }
}
