using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor


{

    public float jumpPower = 1.0f, gravityDif;
    private CharacterController controller;
    private float gravityForce;
    private PlayerAnimator playerAnimator;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate() {
         Movement();
         Rotation();
         Jump();
    }

    protected override void Movement()
    {   
        float realSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift))
            realSpeed = speed* 1.5f;

        float InputZ = Input.GetAxis("Horizontal");
      
       // 1 - setBool(run,true) 2 - setbool(run,false)
       /*if(InputZ != 0)
       {
           playerAnimator.SetAnimation(1);
       }
       else playerAnimator.SetAnimation(2);*/
        //Debug.Log(InputZ);

            controller.Move(transform.right * InputZ * realSpeed * 0.1f);
            controller.Move(transform.up * gravityForce * 0.1f);
        
    }

    protected override void Attack()
    {   
        if(Input.GetKey(KeyCode.Mouse0))
        {

        }
    }

    private void Jump(){

         if (!controller.isGrounded)
        gravityForce -= gravityDif * Time.deltaTime;
            else
        gravityForce = -1f;
        if (Input.GetButton("Jump") && controller.isGrounded){
            
            //playerAnimator.SetAnimation(3);
            gravityForce = jumpPower;
        }
   
    }




}
