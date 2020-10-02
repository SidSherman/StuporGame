using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCustom : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    Vector3 currentEulerAngles;
        Quaternion currentRotation;
    //public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
       // background.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,background.transform.position.z);
        transform.position = new Vector3(target.transform.position.x + 5.0f,target.transform.position.y + 5.0f, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {   
    
        Vector3 position = target.position;
        position.x = position.x + -5.0f;
        position.y = position.y + 5.0f;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime); //постепенно изменяем расстояние от начальной позиции до цели 
       // background.transform.position = position;
       /* float thetaDeg = transform.rotation.y - target.transform.rotation.y; // in degrees

       /* Quaternion rotY = Quaternion.AngleAxis(thetaDeg, Vector3.down);
        Quaternion rotZ = Quaternion.AngleAxis(-35.0f, Vector3.left);
        
        currentRotation += new Vector3();
        //Quaternion RotY = transform.rotation + new Vector
        currentRotation.EulerAngles = 
        transform.rotation = rotY;*/

    }

}
