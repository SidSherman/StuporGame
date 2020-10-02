using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource MusicSource, EffectsSource;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        EffectsSource.volume = PlayerPrefs.GetFloat("EffectsVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
