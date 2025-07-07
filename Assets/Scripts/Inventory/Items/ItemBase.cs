using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] private Transform meshRoot;
    [SerializeField] protected Vector3 itemHandlerPosition;

    [SerializeField] bool isPickable = false;

    public Transform MeshRoot { get => meshRoot; set => meshRoot = value; }

    public Vector3 ItemHandlerPosition { get => itemHandlerPosition; }

    public abstract void Use();
    public virtual void SwitchTurnMesh(bool enabled)
    {
        meshRoot.gameObject.SetActive(enabled);
    }
}