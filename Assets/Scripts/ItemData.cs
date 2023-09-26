using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptble Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType { Exp, Chest, Heal, Haste, Magnet, Pause}

    public ItemType itemType;
    public int itemId;
    public string itemName;
    public string ItemDesc;
    public Sprite itemIcon;
    public GameObject itemPrefab;
}
