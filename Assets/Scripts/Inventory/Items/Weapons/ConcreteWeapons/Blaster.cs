using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : WeaponBase
{
    public override bool Shoot()
    {
        Debug.Log("Shoot");
        return true;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}