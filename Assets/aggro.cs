using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aggro : MonoBehaviour
{

    public CharacterController characterController;
    public float MovementSpeed = 0.1f;
    public float JumpSpeed = 4f;
    public float Gravity = 9.8f;

    private Vector3 moveDirection = Vector3.zero;
    public Animator anim = null;


    public GameObject Player;
    private int jumps;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        moveDirection = transform.right + transform.forward * 0.1f;
        if (moveDirection.magnitude >= 0.1f)
        {
            characterController.Move(moveDirection * MovementSpeed * Time.deltaTime );
            anim.SetBool("isrunning", true);
           
        }
        else
        {
            anim.SetBool("isrunning", false);
        }
        

       
          


       




    }

}
