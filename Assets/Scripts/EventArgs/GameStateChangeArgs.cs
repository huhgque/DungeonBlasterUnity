using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChangeArgs : EventArgs
{
    public bool isGamePause;
    public GameState gameState;
}
