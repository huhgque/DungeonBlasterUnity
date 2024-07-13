using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagedable
{
    public event EventHandler OnEnemyDie;
    [SerializeField] protected EnemySO enemyStat;
    [SerializeField] protected SpriteRenderer sprite;
    protected int currentHp = 0;
    protected Player player;
    protected Rigidbody2D rigiddbody;
    protected virtual void Start() {
        player = Player.Instance;
        rigiddbody = GetComponent<Rigidbody2D>();
        currentHp = enemyStat.hp;
    }

    protected virtual void Update() {
    }
    protected virtual void FixedUpdate() {
        FollowPlayer();        
    }
    protected virtual void FollowPlayer(){
        Vector3 direction = player.transform.position - transform.position;
        // transform.position += direction.normalized * speed * Time.deltaTime;
        Vector2 vector2 = new(direction.x,direction.y);
        rigiddbody.MovePosition( new Vector2(transform.position.x,transform.position.y)  + vector2.normalized * enemyStat.speed * Time.deltaTime ) ;
        if (direction.normalized.x > 0) sprite.flipX = true;
        else sprite.flipX = false;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0){
            GameManager.Instance.GetExperienceDroper().DropExperience(transform.position,enemyStat.exp);
            KillCounter.Instance.CountEntity(enemyStat.enemyName,1);
            OnEnemyDie?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerStay2D(Collider2D other) {
        bool isPlayer = other.TryGetComponent<Player>(out Player colliedPlayer);
        if (isPlayer) colliedPlayer.TakeDamage(enemyStat.damage);
    }
}
