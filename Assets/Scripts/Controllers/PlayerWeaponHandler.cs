using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    private WeaponManager _weaponManager;

    private void OnEnable()
    {
        WeaponManager.Instance.WeaponUpgradeEvent += OnWeaponUpgraded;
    }

    private void Start()
    {
        _weaponManager = WeaponManager.Instance;
    }

    private void OnDisable()
    {
        WeaponManager.Instance.WeaponUpgradeEvent -= OnWeaponUpgraded;
    }

    private void OnWeaponUpgraded(WeaponData data)
    {
        WeaponData weaponDataInstance = null;

        if (_weaponManager.WeaponDatas.Count == 0)
        {
            weaponDataInstance = Instantiate(data);
            _weaponManager.WeaponDatas.Add(weaponDataInstance);
        }
        else
        {
            if (IsWeaponAlreadyExist(data.displayName, out WeaponData weaponData))
            {
                weaponDataInstance = weaponData;
            }
            else
            {
                weaponDataInstance = Instantiate(data);
                _weaponManager.WeaponDatas.Add(weaponDataInstance);
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
            if (weaponDataInstance.level < weaponDataInstance.maxLevel)
            {
                // 기본 무기 스텟 전달
                //PlayerStat stat
                //stat.SetStat(weaponDataInstance.attack, weaponDataInstance.attackSpeed, weaponDataInstance.count);
                weaponDataInstance.level++;
            }
        }
    }

    private bool IsWeaponAlreadyExist(string weaponName, out WeaponData weaponData)
    {
        foreach (var item in _weaponManager.WeaponDatas)
        {
            if (item.displayName.Equals(weaponName))
            {
                weaponData = item;
                return true;
            }
        }

        weaponData = null;
        return false;
    }
}
