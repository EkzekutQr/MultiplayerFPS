using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, IInventoryController
{
    [SerializeField] private List<ItemBase> startItems;

    private List<InventoryBase> inventoryBase = new List<InventoryBase>();
    private IItemsTakingColliderController takingColliderController;

    public IItemsTakingColliderController TakingColliderController { get => takingColliderController; }
    public List<InventoryBase> InventoryBase { get => inventoryBase; }
    public List<ItemBase> StartItems { get => startItems; }

    private void Start()
    {
        InitInventory<WeaponInventory>(startItems);
        Debug.Log(inventoryBase[0].GetType());
    }

    public void InitInventory<T>(List<ItemBase> startItems) where T : InventoryBase
    {
        inventoryBase.Add((InventoryBase)System.Activator.CreateInstance(typeof(T), startItems));
    }

    public void InitItemsTakingColliderController()
    {
        takingColliderController = transform.GetComponentInChildren<IItemsTakingColliderController>();
        StartListenTakingColliderController();
    }

    private void StartListenTakingColliderController()
    {
        takingColliderController.OnItemColliderEnter += AddItem;
    }

    public void AddItem(ItemBase itemBase)
    {
        foreach (var item in inventoryBase)
        {
            if (item.AddItem(itemBase))
                break;
        }
    }
}
public interface IInventoryController
{
    List<InventoryBase> InventoryBase { get; }
    IItemsTakingColliderController TakingColliderController { get; }
    List<ItemBase> StartItems { get; }

    void AddItem(ItemBase itemBase);
    void InitInventory<T>(List<ItemBase> startItems) where T : InventoryBase;
    void InitItemsTakingColliderController();
}