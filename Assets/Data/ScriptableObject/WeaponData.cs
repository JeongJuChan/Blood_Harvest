using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    DefaultUpgrade,
    AdditionalUpgrade,
}

public enum AdditionalWeaponType
{
    Shovel,
    Rake,
    Sickle,
}

[CreateAssetMenu(fileName = "DefaultWeapon", menuName = "CreateWeapon", order = 1)]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Info")]
    public string displayName;
    public string description;
    public WeaponType type;
    public int maxLevel;
    public int level;
    public Sprite icon;

    [Header("Weapon Attack")]
    public float attack;
    public float attackSpeed;
    public int count;
    public float scale;
}
