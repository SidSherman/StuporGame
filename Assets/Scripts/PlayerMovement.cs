using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : Actor


{

    // ПРОСТИТЕ МЕНЯ ЗА ГОВНОКОД Я ИСПРАВЛЮ КАК БУДЕТ ВРЕМЯ
    public float jumpPower = 1.0f, gravityDif = 20, dashSpeed = 20, dashCD = 5, AttackRadius = 2;
    public CharacterController controller;
    private float gravityForce, realspeed, ZPosition;
    private bool canDoubleJump = false, canDash = true, moveRight = true;
   
    private bool dashState = false, 
    idleState = true, 
    jumpState = false, 
    runState = false, 
    attackState = false, 
    damageState = false,
    deadState = false;
    public Transform modelTransform;
    public GameObject EnemySearcher;
    public LayerMask enemyLayer;
    

    // Start is called before the first frame update
    void Start()
    {
        canDoubleJump = false;
        //controller = GetComponent<CharacterController>();
   
        animator = GetComponent <Animator> ();
        ZPosition = transform.position.z;

    }
    

    // Update is called once per frame
    void Update()
    {
        if(!deadState){
            Jump();
            Attack();
        }
      

    }

    private void FixedUpdate() {
        if(!deadState){
         Movement();
         Rotation();
        }
         transform.position = new Vector3(transform.position.x, transform.position.y, ZPosition);
            
    }

    protected override void Movement()
    {   
        
        modelTransform.position = transform.position;
      
        float InputZ = Input.GetAxis("Horizontal");

        if(Input.GetButton("Dash") && canDash)
        {
            dashState = true;
            Dash();
        }


        if (InputZ!=0)
            runState = true;

        
        if(Input.GetButton("Run"))
        {
            realspeed = speed* 1.5f;
        }

        realspeed = speed;
        if(!damageState)
        {
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
        else
        {
            controller.Move(transform.forward * -1 * 7 * 0.1f);
        }

        
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
            attackState = true;
            animator.SetTrigger("Attack");
            Collider[] enemies = 
            Physics.OverlapSphere(EnemySearcher.transform.position, AttackRadius, enemyLayer);
            foreach(Collider enemy in enemies)
            {
                enemy.gameObject.GetComponentInParent<Health>().GetDamage();
                attackState = false;
            }
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
            jumpState = false;
            canDoubleJump = false;
        }
        if (Input.GetButton("Jump") && controller.isGrounded){
            
           
            gravityForce = jumpPower;
            jumpState = true;
            animator.SetTrigger("Jump");
            StartCoroutine(JumpTimer());
           // Debug.Log("Jump");
        }
         if (Input.GetButton("Jump") && !controller.isGrounded && canDoubleJump){
            
            
            gravityForce = jumpPower;
            
            canDoubleJump = false;
            Debug.Log("DoubleJump");
            
        }
       
    
    }

        private void OnControllerColliderHit(ControllerColliderHit hit) {
            if(hit.gameObject.tag == "Enemy")
            {
                damageState = true;
                animator.SetTrigger("GetDamage");
                GetComponent<Health> ().GetDamage();
                StartCoroutine(Damage());
            }
        }
        public Animator GetAnimator()
        {
            return animator;
        }


        public override  void Death()
    {
        deadState = true;
        animator.SetTrigger("Death");
        StartCoroutine (DeathCor());
    }
        IEnumerator DeathCor(){

            yield return new WaitForSeconds(5.0f);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


   
        IEnumerator Damage(){
            yield return new WaitForSeconds(0.2f);
            damageState = false;
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
        dashState = false;
    }

}
