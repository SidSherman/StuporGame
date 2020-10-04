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
        if (HealthCount == 0)
        {   
             Debug.Log("GetDamage");
            if(gameObject.tag == "Player")
                GetComponent<CharacterController> ().enabled = false;
            else
                GetComponent<Collider> ().enabled = false;
        }
    }

    public void Heal(){
        if( HealthCount < MaxHealthCount)
            HealthCount++;


    }

}
