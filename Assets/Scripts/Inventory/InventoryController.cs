using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, IInventoryController, IUsingControllable, IShootingControllable
{
    [SerializeField] private List<ItemBase> startItems;
    [SerializeField] private ItemBase handlingItemOnAwake;

    private List<InventoryBase> inventoryBase = new List<InventoryBase>();
    private IItemsTakingColliderController takingColliderController;
    private IItemHandler itemHandler;

    public IItemsTakingColliderController TakingColliderController { get => takingColliderController; }
    public List<InventoryBase> InventoryBase { get => inventoryBase; }
    public List<ItemBase> StartItems { get => startItems; }

    private void Start()
    {
        InitInventory<WeaponInventory>(startItems);
        InitItemsTakingColliderController();
        InitItemHandlrer();
        Debug.Log(inventoryBase[0].GetType());
    }

    public void InitInventory<T>(List<ItemBase> startItems) where T : InventoryBase
    {
        inventoryBase.Add((InventoryBase)System.Activator.CreateInstance(typeof(T), startItems));
    }

    public void InitItemsTakingColliderController()
    {
        if (takingColliderController != null) return;

        takingColliderController = transform.GetComponentInChildren<IItemsTakingColliderController>();
        StartListenTakingColliderController();
    }

    public void InitItemHandlrer()
    {
        if (itemHandler != null) return;

        itemHandler = transform.GetComponentInChildren<IItemHandler>();
        itemHandler.HandlingItem = handlingItemOnAwake;
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
            {
                if (itemHandler.HandlingItem == null)
                    SetHandlingItem(itemBase);
                break;
            }
        }
    }

    public void SetHandlingItem(ItemBase item)
    {
        if (item == null)
            return;
        itemHandler.HandlingItem = item;
    }

    public void OnUsingPerformed()
    {
        UseHandlingItem();
    }

    private void UseHandlingItem()
    {
        itemHandler.UseHandlingItem();
    }

    private void ShootHandlingWeapon(IWeapon weapon)
    {
        weapon.Shoot();
    }

    public void Use()
    {
        UseHandlingItem();
    }

    public void Shoot()
    {
        if (itemHandler.HandlingItem is IWeapon weapon)
            ShootHandlingWeapon(weapon);
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
public interface IShootingControllable
{
    void Shoot();
}