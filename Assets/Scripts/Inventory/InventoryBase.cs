using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryBase
{
    protected List<ItemBase> items;
    protected ItemBase currentItem;

    public ItemBase CurrentItem { get => currentItem; }

    public InventoryBase(List<ItemBase> initialItems)
    {
        items = initialItems ?? new List<ItemBase>();
    }

    public abstract bool AddItem(ItemBase item);
    public abstract bool RemoveItem(ItemBase item);
    public abstract bool UseItem(ItemBase item);
    public abstract InventoryBase CreateInstance(List<ItemBase> initialItems);
}