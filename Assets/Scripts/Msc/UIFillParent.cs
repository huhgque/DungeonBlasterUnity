using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class UIFillParent : MonoBehaviour
{
    void Start() {
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = -rect.parent.GetComponent<RectTransform>().sizeDelta;
    }
}
