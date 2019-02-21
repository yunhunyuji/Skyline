using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class FSMBase : MonoBehaviour
{
    protected List<Transform> enemys =  new List<Transform>();

    protected Vector3 destPos;

    protected float shootRate;
    protected float elapseTime;//射击的时间间隔

    //针对与我自身框架的方法
    /// <summary>
    /// 初始化
    /// </summary>
    protected virtual void Initialize() { }
    /// <summary>
    /// 更新
    /// </summary>
    protected virtual void FSMUpdate() { }
    /// <summary>
    /// 固定更新
    /// </summary>
    protected virtual void FSMFixedUpdate() { }
    void Start()
    {
        Initialize();
    }
    void Update()
    {
        FSMUpdate();
    }
    void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}
