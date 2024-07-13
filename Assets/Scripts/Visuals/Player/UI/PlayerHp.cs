using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] Image greenBar;
    [SerializeField] Image redBar;
    SmoothBarUtil smoothBarUtil = new();
    Player player;
    void Start() {
        player = Player.Instance;
        player.OnPlayerHealthChange += OnPlayerHealthChange;
        smoothBarUtil.TargetFill = 1;
    }
    void Update() {
        smoothBarUtil.Update();
        greenBar.fillAmount = redBar.fillAmount = smoothBarUtil.CurrentFill;
        greenBar.color = new Color(greenBar.color.r,greenBar.color.g,greenBar.color.b,smoothBarUtil.CurrentFill);
    }
    void OnPlayerHealthChange (object sender , Player.OnPlayerHealthChangeArgs args){
        smoothBarUtil.TargetFill = (float) args.currentHp / args.maxHp;
    }
}
