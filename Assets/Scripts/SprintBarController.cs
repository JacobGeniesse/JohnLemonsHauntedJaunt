using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBarController : MonoBehaviour
{

    public CanvasGroup HealthBarCanvas;
    public Slider slider;

    private bool fadeIn;
    private bool fadeOut;
    
    public void SetMaxSprint(float sprint){
        slider.maxValue = sprint;
        slider.value = sprint;
    }

    public void SetSprint(float sprint){
        slider.value = sprint;
    }

    void Update(){
        
        DetermineFade();

        if(fadeOut == true){
            if(HealthBarCanvas.alpha > 0){
                HealthBarCanvas.alpha -= Time.deltaTime;
            }
        }
        if(fadeIn == true){
            if(HealthBarCanvas.alpha < 1){
                HealthBarCanvas.alpha += Time.deltaTime;
            }
        }
    }

    void DetermineFade(){
        if(slider.value >= slider.maxValue){
		    fadeOut = true;
            fadeIn = false;
        } else if (slider.value <= slider.maxValue){
            fadeIn = true;
            fadeOut = false;
            HealthBarCanvas.alpha = 1;
        }
    }
}
