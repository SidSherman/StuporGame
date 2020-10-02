using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public float speed;
    protected Rigidbody rb;
    protected Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody> ();
        animator = GetComponent <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Movement()
    {

    }
     protected virtual void Rotation()
     {
         
     }

    

}
