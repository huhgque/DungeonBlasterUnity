using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearEvent : WorldEvent
{
    protected override void EventBehaviorOnce()
    {
        GameManager.Instance.GameClear();
    }
}
