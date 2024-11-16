using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase, IWeapon
{
    private ProjectileBase projectile;

    public ProjectileBase Projectile { get => projectile; set => projectile = value; }

    public abstract bool Shoot();
}
