using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class CharaterActionCtrl : MonoBehaviour {

	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Vector3 m_Move;
	private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
	float h = 0;
	float v = 0;
	
	private void Start()
	{
		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCharacter>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	}
	private void SetMove(Vector2 dir){
		this.v = dir.x;
		this.h = dir.y;
	}

	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		bool crouch = Input.GetKey(KeyCode.C);

		m_Move = v*transform.forward + h*transform.right;
		
		
#if !MOBILE_INPUT
		// walk speed multiplier
		if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
		
		if(Input.GetKeyDown(KeyCode.F))
			m_Character.Atk(KeyCode.F);
		if(Input.GetKeyDown(KeyCode.G))
			m_Character.Atk(KeyCode.G);
		if(Input.GetKeyDown(KeyCode.H))
			m_Character.Atk(KeyCode.H);
#endif

		// pass all parameters to the character control script
		m_Character.Move(m_Move, crouch, m_Jump);
		m_Jump = false;
	}
}
