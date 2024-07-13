using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {get; private set;} = null;
    PlayerInput inputs;
    bool isRightFireJustPressed = false;
    bool isLeftFireJustPressed = false;
    bool isFocusWeaponJustPressed = false;
    void Awake() {
        inputs = new();
        inputs.Player.Enable();
        Instance = this;
    }
    void Update() {
        if (GetRightFire() && !isRightFireJustPressed) isRightFireJustPressed = true;
        else isRightFireJustPressed = false;
        if (GetLeftFire() && !isLeftFireJustPressed) isLeftFireJustPressed = true;
        else isLeftFireJustPressed = false; 
        if ( inputs.Player.FocusWeapon.IsPressed() && !isFocusWeaponJustPressed ) isFocusWeaponJustPressed = true;
        else isFocusWeaponJustPressed = false;
    }
    public Vector2 GetMovement(){
        return inputs.Player.Movement.ReadValue<Vector2>();
    }

    public bool GetRightFire(){
        return inputs.Player.FireRight.IsPressed();
    }
    public bool GetRightFireJustPressed(){
        return isRightFireJustPressed;
    }
    public bool GetLeftFire(){
        return inputs.Player.FireLeft.IsPressed();
    }
    public bool GetLeftFireJustPressed(){
        return isLeftFireJustPressed;
    }
    public bool GetFocusWeaponJustPressed(){
        return isFocusWeaponJustPressed;
    }
    public Vector3 GetMousePositionOnWorld(){
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
    public PlayerInput GetPlayerInput(){
        return inputs;
    }
}
