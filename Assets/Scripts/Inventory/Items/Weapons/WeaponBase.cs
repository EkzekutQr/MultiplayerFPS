using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase, IWeapon
{
    // �������������� �������� � ������ ��� ������
    public bool Shoot()
    {
        throw new System.NotImplementedException();
    }
}
