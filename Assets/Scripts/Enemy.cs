using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        animator = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter(Collision other) {
        /*if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().GetDamage();
            Debug.Log("PlayerOnCollider");
        }*/
    }

}
