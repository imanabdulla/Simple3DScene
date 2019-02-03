using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllers : MonoBehaviour
{
    public float m_MoveSpeed = 3;
    public float m_TurnSpeed = 90f;
    public float m_RunSpeed = 5;
    public float m_JumpSpeed = 5f;

    private float m_MoveValue, m_TurnValue, m_RunValue;
    private bool isGrounded, isJumped;
    private Rigidbody m_rigidBody;
    private Animator m_Animator;

	private void Awake ()
    {
        m_rigidBody = this.GetComponent<Rigidbody>();
        m_Animator = this.GetComponent<Animator>();
	}

    private void Start()
    {
        isGrounded = false; isJumped = false;
    }

    private void Update()
    {
        m_MoveValue = CrossPlatformInputManager.GetAxis("Vertical");
        m_TurnValue = CrossPlatformInputManager.GetAxis("Horizontal");
        m_RunValue = CrossPlatformInputManager.GetAxis("Fire1");

        isJumped = (CrossPlatformInputManager.GetButtonDown("Jump")) ? true : false;
    }

    private void FixedUpdate ()
    {
        Move();
        Turn();
        if (isJumped) {
            if (isGrounded) {
                Jump();
                isGrounded = false;
            }
        }
    }

    private void LateUpdate()
    {
        Animate();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MoveValue * m_MoveSpeed * Time.deltaTime;
        if (m_RunValue > 0f)
        {
            movement *= m_RunValue * m_RunSpeed;
           // m_Animator.SetBool("Running", true);
        }
        else
        {
           // m_Animator.SetBool("walking", true);
        }
        m_rigidBody.MovePosition(movement + m_rigidBody.position);
    }

    private void Turn()
    {
        float turn = m_TurnValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_rigidBody.MoveRotation(turnRotation * m_rigidBody.rotation);
    }

    private void Jump ()
    {
        Vector3 jump = transform.up  * m_JumpSpeed;
        m_rigidBody.AddForce(jump, ForceMode.Impulse);
    }

    private void Animate()
    {
        //idle 
        if (isGrounded && Mathf.Abs(m_MoveValue) < 0.1f && Mathf.Abs(m_RunValue) < 0.1f && !isJumped)
            m_Animator.SetBool("IsIdling", true);
        else
            m_Animator.SetBool("IsIdling", false);


        if (Mathf.Abs(m_MoveValue) > 0.1f)
        {
            //run
            if (Mathf.Abs(m_RunValue) > 0.1f)
            {
                m_Animator.SetBool("IsRunning", true);
                m_Animator.SetBool("IsWalking", false);
            }
            //walk
            else
            {
                m_Animator.SetBool("IsWalking", true);
                m_Animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);
            m_Animator.SetBool("IsRunning", false);
        }

        //jump
        if (isJumped) 
            m_Animator.SetBool("Jumping",true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
