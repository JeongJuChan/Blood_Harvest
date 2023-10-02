using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleShooter : Shooter
{
    [SerializeField] private float upgradeSpeed = 1.3f;

    protected override void Shoot()
    {
        if (weapon == null)
        {
            upgradeValue = upgradeSpeed;
            Sickle sickle = CreateNewWeapon() as Sickle;
            weapon = sickle;
            sickle.SetDamage(Data.attack);
            sickle.SetOffsetTransform(transform);
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();
        Sickle sickle = weapon as Sickle;
        sickle.ChangeMoveSpeed(upgradeSpeed);
    }

    protected override void Apply()
    {
        Sickle sickle = weapon as Sickle;
        sickle.ChangeMoveSpeed(upgradeValue);
    }
}
