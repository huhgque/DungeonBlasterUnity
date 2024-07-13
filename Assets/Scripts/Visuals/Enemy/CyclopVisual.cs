using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopVisual : MonoBehaviour
{
    [SerializeField] Cyclop parent;
    [SerializeField] GameObject sprite;
    [SerializeField] GameObject skillParticalContainer;
    [SerializeField] ParticleSystem skillPartical;
    Animator animator;
    void Start() {
        parent.OnSkillStageChange += OnSkillStageChange;
        animator = sprite.GetComponent<Animator>();
        skillPartical.Stop(true,ParticleSystemStopBehavior.StopEmitting);
    }
    void OnSkillStageChange(object sender,Cyclop.OnSkillStageChangeArgs args){
        switch(args.stage){
            case Cyclop.SkillStage.IDLE:
                skillPartical.Stop(true,ParticleSystemStopBehavior.StopEmitting);
                break;
            case Cyclop.SkillStage.WINDUP:
                skillPartical.Play();
                skillParticalContainer.transform.up = -parent.ChargeDirection;
                // TODO : pause walk
                animator.speed = 0;
                break;  
            case Cyclop.SkillStage.FIRE:
                // TODO : resume walk
                animator.speed = 1;
                break;
        }
    }
}
