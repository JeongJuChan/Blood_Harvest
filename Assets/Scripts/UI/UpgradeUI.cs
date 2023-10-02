using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : UIBase
{
    [Header("Weapon Items")]
    [SerializeField] private Transform weaponParent;
    [SerializeField] private int _itemCount = 4;

    private void Start()
    {
        InstantiateRandomItems();
    }

    private void InstantiateRandomItems()
    {
        List<UpgradeItem> upgradeItems = new List<UpgradeItem>(WeaponManager.Instance.WeaponPrefabs);
        int count = _itemCount;

        while (count > 0)
        {
            int index = UnityEngine.Random.Range(0, upgradeItems.Count);
            bool isMax = WeaponManager.Instance.IsLevelMax(upgradeItems[index]);

            if (isMax)
            {
                upgradeItems.Remove(upgradeItems[index]);
                continue;
            }

            Instantiate(upgradeItems[index], weaponParent);

            upgradeItems.Remove(upgradeItems[index]);

            count--;
        }
    }
}
