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
public class CharacterStats : MonoBehaviour
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1, 100)] public int currentHealth;
    [Range(1f, 20f)] public float speed;
    [Range(1f, 100f)] public float exp;
    public int level = 1;

    public AttackSO attackSO;

    private void Update()
    {
        if (exp >= 100)
        {
            level++;
            exp -= 100;
        }
    }
}
