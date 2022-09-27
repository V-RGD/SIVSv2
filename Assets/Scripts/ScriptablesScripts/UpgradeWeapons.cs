using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UpgradeScriptableObject", menuName = "ScriptableObject/Upgrade1")]
public class UpgradeWeapons : ScriptableObject
{
    public string name;
    public string description;
    public int level;
}
