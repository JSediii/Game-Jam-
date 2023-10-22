using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSetting : MonoBehaviour
{
    public Slider sliderHere;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetVolume()
    {
        AudioListener.volume = sliderHere.value;
    }


    
}