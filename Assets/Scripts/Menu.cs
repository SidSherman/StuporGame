using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour



{

public GameObject MenuPanel, SettingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPause();
    }

    public void OCSettings()
    {
        if(SettingsPanel.activeSelf == true)
        {
             MenuPanel.SetActive(true);
            SettingsPanel.SetActive(false);
        }
        else {
            MenuPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
    }

    private void SetPause(){

        if(Input.GetKeyUp(KeyCode.Escape) && Time.timeScale == 0f)
        {
            PauseOff();
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && Time.timeScale == 1f)
        {
            PauseOn();
        }

    }
    public void PauseOn(){
        MenuPanel.SetActive(true);
        Time.timeScale = 0f; // пауза в игре
    }

    public void PauseOff(){
        MenuPanel.SetActive(false); 
        Time.timeScale = 1f; // возобновляем ход времени  
    }




}
