using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    public float Speed { get; set; }
    public WeaponSO WeaponStat;
    protected int pierceCounter = 0;
    protected Vector3 startPos;
    protected Rigidbody2D rigid;
    void Awake()
    {
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }
    void Update()
    {
        DespawnBehevior();
    }
    void FixedUpdate()
    {
        MovementUpdate();
    }
    protected virtual void MovementUpdate()
    {
        rigid.MovePosition(transform.position + transform.up.normalized * Speed * Time.deltaTime * WeaponManager.Instance.ProjectileTimeScale);
    }
    protected virtual void DespawnBehevior()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        bool isEnemy = other.TryGetComponent<Enemy>(out Enemy enemy);
        if (isEnemy)
        {
            enemy.TakeDamage(WeaponDamage());
            pierceCounter++;
            DamageIndicator.AddPlayerDamageIndicator(enemy.transform.position, WeaponDamage());
        }
        CheckPierce();
    }
    void CheckPierce()
    {
        if (WeaponStat.pierce < 0) return;
        if (pierceCounter > WeaponStat.pierce)
        {
            Destroy(gameObject);
        }
    }
    public virtual int WeaponDamage(){
        return WeaponStat.damage;
    }
}
