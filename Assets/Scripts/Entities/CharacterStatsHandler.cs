using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void Start()
    {
        CurrentStats.levelupEvent += OnLevelUp;
    }

    private void OnDestroy()
    {
        CurrentStats.levelupEvent -= OnLevelUp;
    }

    public void ExpUp(int amount)
    {
        CurrentStats.exp += amount;
        Debug.Log(CurrentStats.exp);
        CurrentStats.CheckLevelUp();
    }

    public void Healing(float amount)
    {
        CurrentStats.currentHealth += amount;
        if(CurrentStats.currentHealth > CurrentStats.maxHealth)
            CurrentStats.currentHealth = CurrentStats.maxHealth;
    }

    public IEnumerator SpdBuff(float value, float duration)
    {
        CurrentStats.speed += value;
        yield return new WaitForSeconds(duration);
        CurrentStats.speed -= value;
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new CharacterStats { attackSO = attackSO };
        // TODO
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.currentHealth = baseStats.currentHealth;
        CurrentStats.level = baseStats.level;
        CurrentStats.exp = baseStats.exp;
        CurrentStats.speed = baseStats.speed;
    }



    private void OnLevelUp()
    {
        UIManager.Instance.ShowPopup<UpgradeUI>();
    }

    
}
