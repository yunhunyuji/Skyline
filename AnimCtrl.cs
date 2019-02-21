using UnityEngine;

public enum AnimState{
	Idle,
	Run,
	Atk
}
public class AnimCtrl : MonoBehaviour
{

	Animator m_Animator;
	AnimState animState; 
	void Start()
	{
		m_Animator = GetComponent<Animator>();
		animState = AnimState.Idle;
	}
	void Update()
	{
		switch(animState){
			case AnimState.Idle:
					m_Animator.SetBool("Run",false);
				break;
			case AnimState.Run:
					Debug.Log(true);
					m_Animator.SetBool("Run",true);
				break;
			case AnimState.Atk:
					m_Animator.SetTrigger("Attack");
				break;
		}
	}
	public void SetAnimState(AnimState animState){
		this.animState = animState;
	}
	
}

