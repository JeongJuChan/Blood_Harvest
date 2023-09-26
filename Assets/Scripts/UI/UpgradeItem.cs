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
        Init();
    }

    private void Init()
    {
        weaponImage.sprite = data.icon;
        upgradeNameText.text = data.displayName;
        descriptionText.text = data.description;
    }

    
}
