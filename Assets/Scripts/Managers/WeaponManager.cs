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

    /*public void UpgradeItem(WeaponData data)
    {
        WeaponData weaponDataInstance = null;

        if (_datas.Count == 0)
        {
            weaponDataInstance = UnityEngine.Object.Instantiate(data);
            _datas.Add(weaponDataInstance);
        }
        else
        {
            if (IsWeaponAlreadyExist(data.displayName, out WeaponData weaponData))
            {
                weaponDataInstance = weaponData;
            }
            else
            {
                weaponDataInstance = UnityEngine.Object.Instantiate(data);
                _datas.Add(weaponDataInstance);

            }
        }



        if (weaponDataInstance.type == WeaponType.AdditionalUpgrade)
        {
            AdditionalWeaponType weaponType = AdditionalWeaponType.Shovel;
            foreach (AdditionalWeaponType type in Enum.GetValues(typeof(AdditionalWeaponType)))
            {
                if (weaponDataInstance.displayName.Equals(type))
                {
                    weaponType = type;
                    break;
                }
            }

            switch (weaponType)
            {
                case AdditionalWeaponType.Shovel:

                    break;
                case AdditionalWeaponType.Rake:
                    break;
                case AdditionalWeaponType.Sickle:
                    break;
            }
        }
        else
        {

        }



    }

    private bool IsWeaponAlreadyExist(string weaponName, out WeaponData weaponData)
    {
        foreach (var item in _datas)
        {
            if (item.displayName.Equals(weaponName))
            {
                weaponData = item;
                return true;
            }
        }

        weaponData = null;
        return false;
    }*/
}
