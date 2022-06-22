using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{

    public Animator anim = null;
    public CharacterController controller;
    public float speed = 12f;
    public float jumpspeed = 8.0f;

    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        var up = (Vector3.up);

        if (controller.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            direction = transform.right * horizontal + transform.forward * vertical;


            if (direction.magnitude >= 0.1f)
            {
                controller.Move(direction * speed * Time.deltaTime);
                
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }



            if (Input.GetButtonDown("Jump"))
            {
                
                anim.SetBool("isJumping", true);
                controller.Move(up * jumpspeed * Time.deltaTime);

            }
            else
            {
                anim.SetBool("isJumping", false);

            }
            }

        /* else
        {
            anim.SetBool("isJumping", false);
        }
        */
    }
}
