using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] private Transform meshRoot;

    public Transform MeshRoot { get => meshRoot; set => meshRoot = value; }

    public abstract void Use();
    public virtual void SwitchTurnMesh(bool enabled)
    {
        meshRoot.gameObject.SetActive(enabled);
    }
}