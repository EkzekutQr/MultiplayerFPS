using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryBase<T> : MonoBehaviour, IInventory<T> where T : IItem
{
    protected List<T> items;

    public abstract T GetCurrentItem();
    public abstract bool SetCurrentItem(T item);
    public abstract bool AddItem(T item);
    public abstract bool RemoveItem(T item);
}
