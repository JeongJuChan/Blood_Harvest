using System;
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

    private List<UpgradeItem> _currentItems = new List<UpgradeItem>(); 

    private void Start()
    {
        GameManager.instance.FreezeGame();
        InstantiateRandomItems();
    }

    private void OnDestroy()
    {
        foreach (var item in _currentItems)
        {
            item.closeEvent -= OnUpgradeSelected;
        }
    }

    private void InstantiateRandomItems()
    {
        List<UpgradeItem> upgradeItems = new List<UpgradeItem>(GameManager.instance.Weapon.WeaponPrefabs);

        int count = _itemCount;

        while (count > 0)
        {
            int index = UnityEngine.Random.Range(0, upgradeItems.Count);
            bool isMax = GameManager.instance.Weapon.IsLevelMax(upgradeItems[index]);

            if (isMax)
            {
                upgradeItems.Remove(upgradeItems[index]);
                count--;
                continue;
            }

            UpgradeItem item = Instantiate(upgradeItems[index], weaponParent);
            item.closeEvent += OnUpgradeSelected;
            _currentItems.Add(item);

            upgradeItems.Remove(upgradeItems[index]);

            count--;
        }
    }

    

    private void OnUpgradeSelected()
    {
        GameManager.instance.ResumeGame();
        UIManager.Instance.ClosePopup(this);
    }
}
