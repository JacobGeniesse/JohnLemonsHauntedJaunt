using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Animator m_Animator;
    private Rigidbody rb;
    private Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public bool isWalking;
    public float turnSpeed = 20f;
    public float playerSpeed = 1f;
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Movement
        m_Movement.Set(horizontalInput, 0f, verticalInput);
        m_Movement.Normalize();
        m_Movement = m_Movement * playerSpeed;
        if(Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f){
            isWalking = true;
        }
        else{
            isWalking = false;
        }
        m_Animator.SetBool("isWalking", isWalking);
        if(isWalking)
        {
            if(!m_AudioSource.isPlaying){
                m_AudioSource.Play();
            }
        }
        else{
            m_AudioSource.Stop();
        }
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }
    void OnAnimatorMove(){
        rb.MovePosition(rb.position + m_Movement * m_Animator.deltaPosition.magnitude);
        rb.MoveRotation (m_Rotation);
    }
}
