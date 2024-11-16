using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemsTakingColliderController : MonoBehaviour, IItemsTakingColliderController
{
    [SerializeField] Blaster blaster;
    private Action<ItemBase> OnItemColliderEnter;

    Action<ItemBase> IItemsTakingColliderController.OnItemColliderEnter { get => OnItemColliderEnter; set => OnItemColliderEnter = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.TryGetComponent<ItemBase>(out ItemBase item))
        {
            OnItemColliderEnter?.Invoke(item);
        }
    }
}
