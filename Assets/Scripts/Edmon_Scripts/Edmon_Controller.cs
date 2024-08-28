using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edmon_Controller : MonoBehaviour
{

    [SerializeField] private Rigidbody Edmon_RigidBody;
    [SerializeField] private float Edmon_Speed;
    [SerializeField] float Edmon_SprintSpeed;
    [SerializeField] private Animator Edmon_Animator;
    [SerializeField] float HorizontalMove;
    [SerializeField] float VerticalMove;

    // Start is called before the first frame update
    void Start()
    
    {
        Edmon_Animator = GetComponent<Animator>();
        Edmon_RigidBody = GetComponent<Rigidbody>();
        Edmon_Speed = 5.0f;
        Edmon_SprintSpeed = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {   

        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        if (HorizontalMove !=0 || VerticalMove != 0)
        {
            Edmon_Animator.SetBool("IsWalking", true);  
        }
        else if (HorizontalMove == 0 || VerticalMove == 0)
        {
            Edmon_Animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Edmon_SprintSpeed = 2.0f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            Edmon_SprintSpeed = 1.0f;

        }
    }

    void FixedUpdate()
    {

        
        Vector3 Movement = new Vector3(HorizontalMove, 0, VerticalMove);
        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, Movement, Edmon_Speed * Time.deltaTime, 0f);

        Quaternion Rotation = Quaternion.LookRotation(desiredForward);


        Edmon_RigidBody.MovePosition(transform.position + Movement * Edmon_Speed * Edmon_SprintSpeed * Time.deltaTime);
        Edmon_RigidBody.MoveRotation(Rotation);
    }
}
