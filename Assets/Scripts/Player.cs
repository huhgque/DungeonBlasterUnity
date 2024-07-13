using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagedable
{
    public event EventHandler<OnPlayerHealthChangeArgs> OnPlayerHealthChange;
    public class OnPlayerHealthChangeArgs : EventArgs
    {
        public int maxHp;
        public int currentHp;
    }
    public static Player Instance { get; private set; }
    [SerializeField] LevelManager levelManager;
    public LevelManager GetLevelManager() { return levelManager; }
    [SerializeField] PlayerStatSO playerBaseStat;
    [SerializeField] GameObject animationPlayer;
    Animator animator;
    public PlayerStatSO playerStat
    {
        get
        {
            return playerBaseStat;
        }
        set
        {
            playerBaseStat = value;
            OnPlayerHealthChange?.Invoke(this, new OnPlayerHealthChangeArgs { maxHp = playerStat.hp, currentHp = currentHp });
            transform.localScale *= playerStat.size;
        }
    }
    float iframeColdown = 0;
    bool canTakeDmg = true;
    InputManager input;
    Rigidbody2D rigidbody2d;
    int currentHp;
    void Awake()
    {
        animator = animationPlayer.GetComponent<Animator>();
        playerStat |= playerBaseStat;
        currentHp = playerStat.hp;
        Instance = this;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        input = InputManager.Instance;
        GameManager.Instance.OnGameStateChange += OnGameStateChange;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canTakeDmg)
        {
            iframeColdown += Time.deltaTime;
            if (iframeColdown >= playerStat.iframeTime)
            {
                canTakeDmg = true;
                iframeColdown = 0;
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 moveDirection = input.GetMovement();
        if (moveDirection != Vector2.zero)
        {
            animator.enabled = true;
            Vector3 movement = new(moveDirection.x, moveDirection.y);
            rigidbody2d.MovePosition(transform.position + movement * Time.deltaTime * playerStat.speed);
        }else{
            animator.enabled = false;
        }
    }
    

    public void TakeDamage(int damage)
    {
        if (!canTakeDmg) return;
        currentHp -= damage;
        canTakeDmg = false;
        OnPlayerHealthChange?.Invoke(this, new OnPlayerHealthChangeArgs { maxHp = playerStat.hp, currentHp = currentHp });
        if(currentHp <= 0){
            GameManager.Instance.GameOver();
        }
    }
    public void Heal(int healAmount)
    {
        currentHp = Math.Min(currentHp + healAmount, playerStat.hp);
        OnPlayerHealthChange?.Invoke(this, new OnPlayerHealthChangeArgs { maxHp = playerStat.hp, currentHp = currentHp });
    }
    void OnGameStateChange(object sender, GameStateChangeArgs args)
    {
        enabled = !args.isGamePause;
    }
}
