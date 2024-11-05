using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IItem
{
    public string Name { get; protected set; }
    // Реализация других свойств и методов
}
