using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclop : Enemy
{
    public enum SkillStage{
        IDLE,
        WINDUP,
        FIRE
    }
    public event EventHandler<OnSkillStageChangeArgs> OnSkillStageChange;
    public class OnSkillStageChangeArgs:EventArgs{
        public SkillStage stage; 
    }
    
    [SerializeField] float skillColdown;
    [SerializeField] float skillDistant;
    [SerializeField] float chargeSpeed;
    [SerializeField] float windUpTime;
    float windUpCounter = 0;
    float skillColdownCounter = 0;
    SkillStage skillStage;
    Vector3 chargeStartPosition;
    Vector3 chargeEndPosition;
    Vector3 chargeDirection;
    public Vector3 ChargeDirection {get{return chargeDirection;}}
    protected override void Start()
    {
        base.Start();
        skillStage = SkillStage.IDLE;
    }
    protected override void Update()
    {
        switch (skillStage){
            case SkillStage.IDLE:
                skillColdownCounter += Time.deltaTime;
                if (skillColdownCounter >= skillColdown){
                    skillColdownCounter = 0;
                    skillStage = SkillStage.WINDUP;
                    chargeStartPosition = transform.position;
                    chargeDirection = (player.transform.position - transform.position).normalized;
                    chargeEndPosition = chargeStartPosition + chargeDirection * skillDistant;
                    OnSkillStageChange?.Invoke(this,new OnSkillStageChangeArgs{stage = skillStage});
                    
                }
                break;
            case SkillStage.WINDUP:
                windUpCounter += Time.deltaTime;
                if (windUpCounter >= windUpTime){
                    windUpCounter = 0;
                    skillStage = SkillStage.FIRE;
                    OnSkillStageChange?.Invoke(this,new OnSkillStageChangeArgs{stage = skillStage});
                }
                break;
        }
    }
    protected override void FixedUpdate()
    {
        switch (skillStage){
            case SkillStage.IDLE:
                FollowPlayer();
                break;
            case SkillStage.WINDUP:
                break;
            case SkillStage.FIRE:
                DoSkill();
                break;
        }
    }
    void DoSkill(){
        Vector3 nextPosition = transform.position + chargeDirection*enemyStat.speed*chargeSpeed*Time.deltaTime;
        rigiddbody.MovePosition(nextPosition);
        if ((nextPosition - chargeStartPosition).magnitude >= (chargeEndPosition - chargeStartPosition).magnitude){
            skillStage = SkillStage.IDLE;
            OnSkillStageChange?.Invoke(this,new OnSkillStageChangeArgs{stage = skillStage});
        }
    }
}
