using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void SetAnimation(int parametr){
        if(parametr == 1){
            animator.SetBool("Run", true);
        }
        if(parametr == 2){
            animator.SetBool("Run", false);
        }
        
    }



}
