using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealthCount = 3;
    private int HealthCount;

    // Start is called before the first frame update
    void Start()
    {
         HealthCount = MaxHealthCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(){
        HealthCount--;
        Debug.Log("GetDamage " + gameObject.name + HealthCount);
        if (HealthCount == 0)
        {   
             
            if(gameObject.tag == "Player")
                {
                    GetComponent<PlayerMovement> ().Death();
                    
                
                }
            if(gameObject.tag == "Enemy")
            {
                GetComponent<Enemy> ().Death();
            }
               
        }
    }

    /*public void Heal(){
        if( HealthCount < MaxHealthCount)
            HealthCount++;


    }*/

}
