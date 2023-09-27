using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeShooter : Shooter
{
    private Rake _rake;
    protected override IEnumerator Shoot()
    {
        if (_rake == null)
        {
            _rake = CreateNewWeapon() as Rake;
        }

        yield return CoroutineRef.GetWaitForSeconds(timePerAttack);
        _rake.SetOffsetTransform(transform);

        StartCoroutine(Shoot());
    }
}
