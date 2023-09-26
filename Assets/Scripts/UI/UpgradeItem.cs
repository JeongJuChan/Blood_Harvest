using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    [Header("Data")]
    public WeaponData data;

    [Header("Item Info")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    void Start()
    {
        SetItemInfoTexts();
    }

    private void SetItemInfoTexts()
    {
        weaponImage.sprite = data.icon;
        upgradeNameText.text = data.displayName;
        descriptionText.text = data.description;

        WeaponData tempData = null;
        foreach (WeaponData weaponData in WeaponManager.Instance.WeaponDatas)
        {
            if (data.displayName.Equals(weaponData.displayName))
            {
                tempData = weaponData;
                break;
            }
        }

        if (data.type == WeaponType.DefaultUpgrade)
        {
            levelText.text = tempData == null ? $"Level : {data.level}" : $"Level : {tempData.level}";
        }
        else
        {
            levelText.text = tempData == null ? levelText.text : $"Level : {tempData.level}";
        }
    }

    
}
