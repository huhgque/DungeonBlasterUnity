using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    [SerializeField] bool destroyOnTimeOut = true;
    [SerializeField] float setTimeOut = 1.0f;
    [SerializeField] bool useUnscaledTime = false;
    float counter = 0;
    void Update(){
        counter += useUnscaledTime?Time.unscaledDeltaTime:Time.deltaTime;
        if (counter >= setTimeOut){
            if(destroyOnTimeOut){
                Destroy(gameObject);
            }else{
                gameObject.SetActive(false);
            }
        }
    }

}
