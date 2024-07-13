using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade",menuName = "SO/Upgrade")]
public class UpgradeOptionSO : ScriptableObject
{
    public EUpgradePath UpgradePath;
    public ScriptableObject upgradeInfo;
    public int selectTime = 1;
}
