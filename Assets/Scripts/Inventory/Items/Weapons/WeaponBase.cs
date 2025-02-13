using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase, IWeapon
{
    [SerializeField] protected List<ProjectileBase> projectiles;
    protected ProjectileBase projectile;

    public ProjectileBase Projectile { get => projectile; set => projectile = value; }

    public abstract bool Shoot();
}
