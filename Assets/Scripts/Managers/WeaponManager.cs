using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager
{
    private static WeaponManager _instance;
    public static WeaponManager Instance { get => GetInstance(); }

    public HashSet<UpgradeItem> WeaponPrefabs { get; private set; }
    public HashSet<WeaponData> WeaponDatas { get; private set; } = new HashSet<WeaponData>();

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
        WeaponPrefabs = new HashSet<UpgradeItem>(Resources.LoadAll<UpgradeItem>(ITEM_UI_PATH));
    }

    public bool IsLevelMax(UpgradeItem item)
    {
        string itemName = item.data.displayName;
        foreach (var data in WeaponDatas)
        {
            if (data.displayName.Equals(itemName))
            {
                WeaponPrefabs.Remove(item);
                return true;
            }
        }

        return false;
    }

    public void UpgradeWeapon(WeaponData data)
    {
        WeaponUpgradeEvent?.Invoke(data);
    }
}
