using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{

    public Slider MusicSlider, EffectsSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("EffectsVolume"))
        {
            PlayerPrefs.SetFloat("EffectsVolume", 5f) ;
        }
         if(!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 5f) ;
        }
            MusicSlider.value =  PlayerPrefs.GetFloat("MusicVolume") ;
            EffectsSlider.value =  PlayerPrefs.GetFloat("EffectsVolume") ;
           
    }

    public void EffectsVolumeChanged(){
        PlayerPrefs.SetFloat("EffectsVolume", EffectsSlider.value);
    }

     public void MusicVolumeChanged(){
         PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
