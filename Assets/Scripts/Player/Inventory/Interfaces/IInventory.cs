using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory<T> where T : IItem
{
    T GetCurrentItem();
    bool SetCurrentItem(T item);
    bool AddItem(T item);
    bool RemoveItem(T item);
}
