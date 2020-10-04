using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public Transform PlayerSearcher;
    public float SearcherRadius = 10, attackRadious = 3;
    private GameObject player;
    //private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        animator = GetComponent<Animator> ();
        //rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
     private void FixedUpdate() {
        //SearchPlayer();
        
        Attack();
    }


    private bool SearchPlayer(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(PlayerSearcher.position, radius);
        foreach (Collider item in colliders)
        {
            if (item.gameObject.tag == "Player"){
                player = item.gameObject;
                return true;
            }
        }
        return false;

    }

    protected override void Movement()
    {    
        if(SearchPlayer(SearcherRadius))
        {
            //Debug.Log(player);
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(player.transform.position.x, transform.position.y, transform.position.z),
                speed * Time.deltaTime);
            if(player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f,90.0f, 0.0f));
                
                //rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            }
            else if(player.transform.position.x < transform.position.x){
                transform.rotation = Quaternion.Euler(new Vector3(0.0f,-90.0f, 0.0f));
               // rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            }
        }
    }
    protected override void Attack()
    {
       
        if(SearchPlayer(attackRadious))
        {
            //Debug.Log("AttackPlayer");
            animator.SetTrigger("Attack");
        }
    }

    public override  void Death()
    {
        Debug.Log("Death");
        animator.SetTrigger("Death");
        Collider[] col = GetComponentsInChildren<Collider>();
        foreach (Collider item in col)
        {
         item.enabled = false;   
        }
        StartCoroutine (DeathCor());
    }
    IEnumerator DeathCor(){

        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }


    /*
        private void OnCollisionEnter(Collision other) {
            Debug.Log("PlayerOnCollider");
        }

        private void OnTriggerEnter(Collider other) {
             Debug.Log("PlayerOnCollider");
            if (other.gameObject.tag == "PlayerWeapon")
            {
                GetComponent<Health>().GetDamage();
                Debug.Log("PlayerOnCollider");

            }
        }*/


/*
    private void OnCollisionEnter(Collision other) {
        Debug.Log("PlayerOnCollider");
    }

    private void OnTriggerEnter(Collider other) {
         Debug.Log("PlayerOnCollider");
        if (other.gameObject.tag == "PlayerWeapon")
        {
            GetComponent<Health>().GetDamage();
            Debug.Log("PlayerOnCollider");
        
        }
    }*/

}
