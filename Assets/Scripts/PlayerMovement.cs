using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor


{

    public float jumpPower = 1.0f, gravityDif;
    private CharacterController _controller;
    private float RotHor  = 0.0f, gravityForce;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
         _controller = GetComponent<CharacterController>();
     
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
        float InputX = Input.GetAxis("Vertical");
        float InputZ = Input.GetAxis("Horizontal");
        Vector3 InputVector = (new Vector3(InputX, 0, InputZ)).normalized;
       
        
        _controller.Move(transform.forward * InputX * speed * 0.1f);
        _controller.Move(transform.right * InputZ * speed * 0.1f);
        _controller.Move(transform.up * gravityForce * 0.1f);


    }


    private void Jump(){

         if (!_controller.isGrounded)
        gravityForce -= gravityDif * Time.deltaTime;
            else
        gravityForce = -1f;
            if (Input.GetButton("Jump") && _controller.isGrounded)
        gravityForce = jumpPower;
   
    }
    protected override void Rotation()
    {   
   
        RotHor += Input.GetAxis("Mouse X");
        
        Quaternion rot = Quaternion.AngleAxis(-RotHor, Vector3.down);
        transform.rotation = rot;
      


    }


}
