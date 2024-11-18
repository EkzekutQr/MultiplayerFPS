using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour, IItemHandler
{
    [SerializeField] private ItemBase handlingItem;

    public ItemBase HandlingItem { get => handlingItem; set => handlingItem = value; }

    public Transform Root => transform;

    public void UseHandlingItem()
    {
        handlingItem.Use();
    }
    public void SetHandlingItem(ItemBase item)
    {
        handlingItem?.SwitchTurnMesh(false);

        handlingItem = item;
        handlingItem.SwitchTurnMesh(true);
    }
}

public interface IItemHandler
{
    ItemBase HandlingItem { get; set; }
    Transform Root { get; }

    void SetHandlingItem(ItemBase item);
    public abstract void UseHandlingItem();
}