using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemsTakingColliderController
{
    public Action<ItemBase> OnItemColliderEnter { get; set; }
}
