public interface IWeapon
{
    ProjectileBase Projectile { get; set; }

    public abstract bool Shoot();
}