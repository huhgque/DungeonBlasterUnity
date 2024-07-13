using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler<GameStateChangeArgs> OnGameStateChange;
    public static GameManager Instance;
    public class ScreenPosition{
        public Vector2 bottomLeft = new();
        public Vector2 topRight = new();
    }
    public ScreenPosition ScreenPos = new();
    [SerializeField] float speedHack = 1;
    [SerializeField] ExperienceDroper experienceDroper;
    [SerializeField] MobSpawnerManager mobSpawnerManager;
    [SerializeField] LevelupBonusManager levelupBonusManager;
    public ExperienceDroper GetExperienceDroper() {return experienceDroper;}
    public MobSpawnerManager GetMobSpawnerManager() {return mobSpawnerManager;}
    public LevelupBonusManager GetLevelupBonusManager() {return levelupBonusManager;}
    bool isGamePause = false;
    GameState gameState = GameState.PLAY;
    public float PlayTimeCounter {private set; get;} = 0;
    void Awake() {
        Instance = this;
        Time.timeScale = speedHack;
        UpdateScreenPos();
        DDOLManager.FindDDOLObject("BackgroundMusic")?.GetComponent<BackgroundMusicManager>().GameMode();
    }
    void Start(){
        InputManager.Instance.GetPlayerInput().Player.Escape.performed += OnEscPress;
    }
    void Update() {
        UpdateScreenPos();
        if (!isGamePause) PlayTimeCounter += Time.unscaledDeltaTime;
    }
    public bool IsPause(){
        return isGamePause;
    }
    public void PauseGame(){
        isGamePause = true;
        gameState = GameState.PAUSE_UPGRADE;
        Time.timeScale = 0;
        OnGameStateChange?.Invoke(this,new GameStateChangeArgs{isGamePause = isGamePause,gameState = gameState});
    }
    public void PauseMenu(){
        isGamePause = true;
        gameState = GameState.PAUSE_MENU;
        Time.timeScale = 0;
        OnGameStateChange?.Invoke(this,new GameStateChangeArgs{isGamePause = isGamePause,gameState = gameState});
    }
    public void ContinueGame(){
        isGamePause = false;
        gameState = GameState.PLAY;
        Time.timeScale = speedHack;
        OnGameStateChange?.Invoke(this,new GameStateChangeArgs{isGamePause = isGamePause,gameState = gameState});
    }
    public void GameOver(){
        Time.timeScale = 0;
        isGamePause = true;
        gameState = GameState.GAME_OVER;
        OnGameStateChange?.Invoke(this,new GameStateChangeArgs{isGamePause = isGamePause,gameState = gameState});
    }
    public void GameClear(){
        Time.timeScale = 0;
        isGamePause = true;
        gameState = GameState.GAME_CLEAR;
        OnGameStateChange?.Invoke(this,new GameStateChangeArgs{isGamePause = isGamePause,gameState = gameState});
    }
    public Resolution windowSize {
        get {
            return Screen.currentResolution;
        }
    }
    private void OnEscPress(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        PauseMenu();
    }
    void UpdateScreenPos(){
        Vector3 bottomLeftPos = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        ScreenPos.bottomLeft.Set(bottomLeftPos.x,bottomLeftPos.y);
        Vector3 res = new Vector3(windowSize.width,windowSize.height,0);
        Vector3 topRightPos = Camera.main.ScreenToWorldPoint(res);
       ScreenPos.topRight.Set(topRightPos.x,topRightPos.y);
    }
    void OnDestroy(){
        InputManager.Instance.GetPlayerInput().Player.Escape.performed -= OnEscPress;
    }
}
