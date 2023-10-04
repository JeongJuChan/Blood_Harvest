using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDropTable : ScriptableObject
{
    [System.Serializable]
    public class Items
    {
        [Range(0f, 100f)] public float dropRate;
        public string itemName;
        public GameObject itemPrefab;
    }

    public List<Items> items = new List<Items>();

    protected List<Items> PickItem()
    {
        List<Items> droppedItems = new List<Items>();

        foreach (var item in items)
        {
            var rnd = Random.Range(0f, 100f);
            if (rnd <= item.dropRate)
            {
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    public void ItemDrop(Vector3 position)
    {
        foreach (var item in PickItem())
        {
            Instantiate(item.itemPrefab, position, Quaternion.identity);
        }
    }
}
