using System;
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
    private Button _selectButton;

    public event Action closeEvent;

    private void Awake()
    {
        _selectButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _selectButton.onClick.AddListener(OnClickUpgradeButton);
    }

    void Start()
    {
        SetItemInfoTexts();
    }

    private void OnDisable()
    {
        _selectButton.onClick.RemoveListener(OnClickUpgradeButton);
    }

    private void OnClickUpgradeButton()
    {
        GameManager.instance.Weapon.UpgradeWeapon(data);
        closeEvent?.Invoke();


    }

    private void SetItemInfoTexts()
    {
        weaponImage.sprite = data.icon;
        upgradeNameText.text = data.displayName;
        descriptionText.text = data.description;

        WeaponData tempData = null;
        foreach (WeaponData weaponData in GameManager.instance.Weapon.WeaponDatas)
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
