using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : InventoryBase
{
    public WeaponInventory(List<ItemBase> initialItems) : base(initialItems)
    {
        InitItems(initialItems);
    }

    private void InitItems(List<ItemBase> initialItems)
    {
        foreach (var item in initialItems)
        {
            AddItem(item);
        }
    }

    public override bool AddItem(ItemBase item)
    {
        if (items.Contains(item)) return false;
        if (!item.TryGetComponent<IWeapon>(out IWeapon iWeapon)) return false;

        items.Add(item);

        return true;
    }

    public override bool RemoveItem(ItemBase item)
    {
        if (!items.Contains(item)) return false;

        items.Remove(item);

        return true;
    }

    public override bool SetCurrentItem(ItemBase item)
    {
        if (!items.Contains(item)) return false;

        currentItem = item;

        return true;
    }

    public override bool UseItem(ItemBase item)
    {
        if (!items.Contains(item)) return false;
        if (!item.TryGetComponent<IWeapon>(out IWeapon iWeapon)) return false;

        iWeapon.Shoot();

        return true;
    }
    public override InventoryBase CreateInstance(List<ItemBase> initialItems)
    {
        return new WeaponInventory(initialItems);
    }
}
