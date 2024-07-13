using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoSO : ScriptableObject
{
    public string itemName;
    [Multiline] public string description;
    public Sprite image;
}
