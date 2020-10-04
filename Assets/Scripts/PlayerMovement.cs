using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor


{

    public float jumpPower = 1.0f, gravityDif = 20, dashSpeed = 20, dashCD = 5;
    public CharacterController controller;
    private float gravityForce, realspeed;
    private bool canDoubleJump = false, canDash = true, moveRight = true;
    public Transform modelTransform;

    // Start is called before the first frame update
    void Start()
    {
        canDoubleJump = false;
        //controller = GetComponent<CharacterController>();
   
        animator = GetComponent <Animator> ();
        

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
        
        modelTransform.position = transform.position;
        realspeed = speed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            
            realspeed = speed* 1.5f;
        }

        float InputZ = Input.GetAxis("Horizontal");
      
        if(Input.GetButton("Dash") && canDash)
        {
            Dash();
        }

        if(InputZ > 0 )
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f,90.0f, 0.0f));
               // animator.SetBool("Run", true);
               //Debug.Log("moveRight");
            }
        else if(InputZ < 0)
        {
            //Debug.Log("moveLeft");
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 0.0f));
                //animator.SetBool("Run", true);
        }
            if (controller.isGrounded)
                animator.SetBool("Run", InputZ !=0);
            
            controller.Move(transform.forward * Mathf.Abs(InputZ) * realspeed * 0.1f);
            controller.Move(transform.up * gravityForce * 0.1f);
        
    }

    void Dash()
    {
        animator.SetTrigger("Dash");
         controller.Move(transform.forward * dashSpeed * 0.1f);
        StartCoroutine(DashTimer(dashCD));
    }

    protected override void Attack()
    {   
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }
    protected void Protect()
    {   
        if(Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Protect");
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

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.tag == "Enemy")
            {
                GetComponent<Health>().GetDamage();
            }
        }

        IEnumerator JumpTimer(){

        yield return new WaitForSeconds(0.5f);
        //canDoubleJump = true;
    }
        IEnumerator DashTimer(float time){

        yield return new WaitForSeconds(0.1f);
        canDash = false;
        yield return new WaitForSeconds(time);
        canDash = true;
    }

}
