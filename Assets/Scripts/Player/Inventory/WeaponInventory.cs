using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponInventory<T> : InventoryBase<T> where T : IWeapon
{
    public WeaponInventory(List<T> initialItems)
    {
        items = initialItems ?? new List<T>();
    }

    public override bool AddItem(T item)
    {
        items.Add(item);
        return true;
    }

    public override T GetCurrentItem()
    {
        return items.FirstOrDefault();
    }

    public override bool RemoveItem(T item)
    {
        return items.Remove(item);
    }

    public override bool SetCurrentItem(T item)
    {
        // Логика установки текущего предмета
        return true;
    }
}