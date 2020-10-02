using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject Credits;
    private bool credintActive = false;


    // Start is called before the first frame update
    void Start()
    
    {
        

    }
    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCredits()
    {
        if (credintActive == true)
        {
                Credits.SetActive(false);
                credintActive = false;
        }
        else 
        {
            credintActive = true;
            Credits.SetActive(true);
        }
    }


    public void Close()
    {
        Application.Quit();
    }


}
