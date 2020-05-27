using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSound : MonoBehaviour
{
    private AudioSource audio;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        audio= GetComponent<AudioSource>();
        audio.loop = true;
        audio.Play();
    }

    
    // Update is called once per frame
    void Update()
    {
        audio.volume = slider.value;
    }
}
