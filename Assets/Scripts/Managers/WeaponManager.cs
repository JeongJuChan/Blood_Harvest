using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager
{
    private static WeaponManager _instance;
    public static WeaponManager Instance { get => GetInstance(); }

    public List<UpgradeItem> WeaponPrefabs { get; private set; }
    public List<WeaponData> WeaponDatas { get; private set; } = new List<WeaponData>();

    [Header("Resource Path")]
    private const string ITEM_UI_PATH = "UI/Weapons/";

    public event Action<WeaponData> WeaponUpgradeEvent;

    private static WeaponManager GetInstance()
    {
        if (_instance == null)
            _instance = new WeaponManager();

        return _instance;
    }

    public WeaponManager()
    {
        WeaponPrefabs = new List<UpgradeItem>(Resources.LoadAll<UpgradeItem>(ITEM_UI_PATH));
    }

    public bool IsLevelMax(UpgradeItem item)
    {
        string itemName = item.data.displayName;
        foreach (var data in WeaponDatas)
        {
            if (data.displayName.Equals(itemName))
            {
                if (data.level >= data.maxLevel)
                {
                    WeaponPrefabs.Remove(item);
                    return true;
                }
            }
        }

        return false;
    }

    public void UpgradeWeapon(WeaponData data)
    {
        WeaponUpgradeEvent?.Invoke(data);
    }

    public void OnUpgraded(WeaponData data)
    {
        for (int i = 0; i < WeaponDatas.Count; i++)
        {
            if (WeaponDatas[i].displayName.Equals(data.displayName))
            {
                WeaponDatas[i] = data;
                break;
            }
        }


    }
}
