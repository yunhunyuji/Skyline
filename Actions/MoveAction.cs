using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.Characters.ThirdPerson;
using DG.Tweening;

public class MoveAction : ActionBehavior {
	public GameObject tile{set;get;}
	public CharaterActionCtrl ctActionCtrl;
	private AnimCtrl m_Character;
	/// <summary>
	/// 获取或设置机动力
	/// </summary>
	public float Mov { get; set; }
	public Vector3 des;
	float v = 0;
	float h = 0;
	public float speed = 0.8f;
	void Start () {
		Mov = 4;
		des = transform.position;
		ButtonPic = Resources.Load<Sprite>("Sprite/Foot");
		ctActionCtrl = GetComponent<CharaterActionCtrl>();
		m_Character = GetComponent<AnimCtrl>();
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics .Raycast (ray,out hit,int.MaxValue)){
				/* if(hit.transform.tag.Equals("Tile")){
					des = hit.transform.position + new Vector3(0,0.5f,0);
				}  */
				LookAtTarget(hit.point);
			}
		}
		if(Vector3.Distance(transform.position,des) > 0.3)
			SimpleMove();
		else{
			m_Character.SetAnimState(AnimState.Idle);
		}
	}

	public override Action GetClickAction(){
		return delegate() {
			
		};
	}
	public void Move(Vector3 des){
		
		//Vector3 dir = checkTargetDirForMe(des);
		if(Vector3.Dot(transform.forward, des.normalized) > 0)	// 返回值为正时,目标在自己的右方,反之在自己的左方
		{
			Debug.Log("右");
			if(h<0)
				h = 0;
			if(h < 1){
				h+=Time.deltaTime;
			}
		}
		else{
			if(Vector3.Dot(transform.forward, des.normalized) == 0)
				h = 0;
			else{
				Debug.Log("左");
				if(h>0)
					h=0;
				if(h > -1){
					h-=Time.deltaTime;
				}
			}
		}

		SendMessage("SetMove",new Vector2(v,h));
	}
	public Vector3 checkTargetDirForMe(Vector3 target)
    {
        //xuqiTest：  target.position = new Vector3(3, 0, 5);
        Vector3 dir = target - transform.position; //位置差，方向
        //方式1   点乘
        //点积的计算方式为: a·b =| a |·| b | cos < a,b > 其中 | a | 和 | b | 表示向量的模 。
        float dot = Vector3.Dot(transform.forward, dir.normalized);//点乘判断前后   //dot >0在前  <0在后 
        float dot1 = Vector3.Dot(transform.right, dir.normalized);//点乘判断左右    //dot1>0在右  <0在左                                               
        float angle = Mathf.Acos(Vector3.Dot(transform.forward.normalized, dir.normalized)) * Mathf.Rad2Deg;//通过点乘求出夹角

		return new Vector3(dot,dot1,angle);
	}
	void LookAtTarget(Vector3 hitPoint) {
        des = hitPoint;
        des = new Vector3(des.x, transform.position.y, des.z);
        transform.LookAt(des);
    }
	private Vector3 moveDirection = Vector3.zero;
	public void SimpleMove() {
		

	
		transform.LookAt(des);
		transform.DOLocalMove(des,Vector3.Distance(transform.position,des)/speed);
		Debug.Log("Run");
		m_Character.SetAnimState(AnimState.Run);
    }
}
