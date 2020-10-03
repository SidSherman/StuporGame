using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor


{

    public float jumpPower = 1.0f, gravityDif;
    private CharacterController controller;
    private float gravityForce;
    private bool canDoubleJump = false, moveRight = true;
  
    public Transform modelTransform;

  
    
    
    // Start is called before the first frame update
    void Start()
    {
        canDoubleJump = false;
        controller = GetComponent<CharacterController>();
   
        animator = GetComponentInChildren <Animator> ();
        

    }
    

    // Update is called once per frame
    void Update()
    {
       Jump();
       Attack();
    }

    private void FixedUpdate() {
         Movement();
         Rotation();
         
    }

    protected override void Movement()
    {   
        float realSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Input");
            realSpeed = speed* 1.5f;
        }

        float InputZ = Input.GetAxis("Horizontal");
    
        
        if(InputZ > 0 )
            {
                modelTransform.rotation = Quaternion.Euler(new Vector3(0.0f,90.0f, 0.0f));
               // animator.SetBool("Run", true);
               Debug.Log("moveRight");
            }
        else if(InputZ < 0)
        {
            Debug.Log("moveLeft");
            modelTransform.rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 0.0f));
                //animator.SetBool("Run", true);
        }
            if (controller.isGrounded)
                animator.SetBool("Run", InputZ !=0);
           
            controller.Move(transform.right * InputZ * realSpeed * 0.1f);
            controller.Move(transform.up * gravityForce * 0.1f);
        
    }

    protected override void Attack()
    {   
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void Jump(){

         if (!controller.isGrounded)
            
            gravityForce -= gravityDif * Time.deltaTime;
        else{
            
            gravityForce = -1f;
            
            canDoubleJump = false;
        }
        if (Input.GetButton("Jump") && controller.isGrounded){
            
           
            gravityForce = jumpPower;
            animator.SetTrigger("Jump");
            StartCoroutine(JumpTimer());
            Debug.Log("Jump");
        }
         if (Input.GetButton("Jump") && !controller.isGrounded && canDoubleJump){
            
            
            gravityForce = jumpPower;
            
            canDoubleJump = false;
            Debug.Log("DoubleJump");
            
        }
       
    
    }


        IEnumerator JumpTimer(){
             
        yield return new WaitForSeconds(0.5f);
        canDoubleJump = true;
    }

}
