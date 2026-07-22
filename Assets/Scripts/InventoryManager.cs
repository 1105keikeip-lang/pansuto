using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InventoryManager Instance;
    public ItemData[] startItems;

     
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        foreach (var item in startItems)
            InventoryManager.Instance.AddItem(item, 1);
    }

    public Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();

    public ItemData weapon;
    public ItemData armor;
    public ItemData accessory1;
    public ItemData accessory2;

    public void AddItem(ItemData item, int count = 1)
    {
        if (items.ContainsKey(item))
            items[item] += count;
        else
            items[item] = count;
    }

    public void RemoveItem(ItemData item, int count = 1)
    {
        if (!items.ContainsKey(item)) return;

        items[item] -= count;
        if (items[item] <= 0)
            items.Remove(item);
    }

    public void UseItem(ItemData item)
    {
        FindFirstObjectByType<ItemUseSystem>().UseItem(item);

        RemoveItem(item, 1);
    }
}
