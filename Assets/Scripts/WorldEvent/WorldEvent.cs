using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEvent : MonoBehaviour
{
    /**
        second
    **/
    [SerializeField] protected float eventDelay;
    [SerializeField] protected float eventDuration;
    [SerializeField] protected WorldEvent nextEvent;
    [SerializeField] protected bool isEventStart = false;
    float durationCoundown = 0;
    void Start() {
        if (isEventStart) StartEvent();
        GameManager.Instance.OnGameStateChange += OnGameStateChange;
    }
    void Update() {
        if (eventDelay != 0){
            eventDelay -= Time.deltaTime;
            if (eventDelay <= 0){
                eventDelay = 0;
                StartEvent();
            }
        }
        if (!isEventStart) return;
        EventBehavior();
        durationCoundown += Time.deltaTime;
        if (durationCoundown >= eventDuration){
            StopEvent();
            nextEvent?.StartEvent();
        }
    }
    
    public void StartEvent(){
        isEventStart = true;
        EventBehaviorOnce();
    }
    public void StopEvent(){
        isEventStart = false;
        OnEventStop();
    }
    protected virtual void EventBehavior(){}
    protected virtual void EventBehaviorOnce(){}
    protected virtual void OnEventStop(){}

    void OnGameStateChange(object sender, GameStateChangeArgs args){
        enabled = !args.isGamePause;
    }
    ~WorldEvent(){
        GameManager.Instance.OnGameStateChange -= OnGameStateChange;
    }
}
