using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public float maxHealth;
    [Range(1, 100)] public float currentHealth;
    [Range(1f, 20f)] public float speed;
    [SerializeField] public int maxExp = 100;
    public int exp;
    public int level = 1;

    [Header("Default Weapon Stats")]
    [Range(1f, 20f)] public float damage = 3;
    [Range(1f, 20f)] public float attackSpeed = 1;
    [Range(1f, 20f)] public int count = 1;

    public AttackSO attackSO;

    public event Action levelupEvent;

    public void CheckLevelUp()
    {
        if (exp >= maxExp)
        {
            level++;
            exp -= maxExp;
            maxExp += level * 10;
            levelupEvent?.Invoke();
        }

        GameManager.instance.ShowLevelState(level, exp, maxExp);
    }
}
