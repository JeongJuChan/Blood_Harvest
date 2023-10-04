using System.Collections;
using UnityEngine;

public class RakeShooter : Shooter
{
    [SerializeField] private float upgradeScale = 0.1f;

    protected override void Shoot()
    {
        upgradeValue = upgradeScale;
        StartCoroutine(CoShoot());
    }

    private IEnumerator CoShoot()
    {
        if (weapon == null)
        {
            Rake rake = CreateNewWeapon() as Rake;
            weapon = rake;
            Init(rake);
        }

        yield return CoroutineRef.GetWaitForSeconds(timePerAttack);

        StartCoroutine(CoShoot());
    }

    public override void Upgrade()
    {
        Data.scale += upgradeScale;
        base.Upgrade();
    }

    private void Init(Rake rake)
    {
        rake.SetDamage(Data.attack);
        rake.SetOffsetTransform(transform);
    }

    protected override void Apply()
    {
        Rake rake = weapon as Rake;
        rake.ChangeScale(upgradeValue);
    }
}
