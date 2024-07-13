using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] float orbSpeed = 2f;
    bool isGoToPlayer = false;
    void Update() {
        if (!isGoToPlayer) return;
        if(Time.timeScale == 0) return;
        transform.position = Vector3.Slerp(transform.position,Player.Instance.transform.position,Time.deltaTime * orbSpeed);
        orbSpeed *= 1.1f;
        if ( (transform.position-Player.Instance.transform.position).magnitude <= Player.Instance.GetComponent<BoxCollider2D>().size.x/2 ){
            Destroy(gameObject);
        }
    }
    public void SetValue(int expValue){
        value = expValue;
    }
    public void GoToPlayer(){
        isGoToPlayer = true;
    }
    void OnTriggerEnter2D(Collider2D other) {
        bool isPlayer = other.TryGetComponent<LevelManager>(out LevelManager player);
        if (isPlayer) {
            player.TakeExp(value);
            GoToPlayer();
        } 
    }
}
