using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour, IItemHandler
{
    [SerializeField] private ItemBase handlingItem;

    public ItemBase HandlingItem { get => handlingItem; set => handlingItem = value; }

    public void UseHandlingItem()
    {
        handlingItem.Use();
    }
}

public interface IItemHandler
{
    ItemBase HandlingItem { get; set; }

    public abstract void UseHandlingItem();
}