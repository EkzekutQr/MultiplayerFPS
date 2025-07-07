using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : ItemBase, IProjectile
{
    private float speed;
    private float damage;

    public float Speed { get => speed; set => speed = value; }
    public float Damage { get => damage; set => damage = value; }
}
public interface IProjectile
{
    float Speed { get; set; }
    float Damage { get; set; }
}