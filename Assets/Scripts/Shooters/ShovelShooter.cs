using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelShooter : Shooter
{
    private const int ANGLE = 360;
    bool isEven = false;

    private List<Shovel> shovels = new List<Shovel>();

    [SerializeField] private int upgradeCount = 1;

    protected override void Shoot()
    {
        upgradeValue = upgradeCount;
        StartCoroutine(CoShoot());
    }

    private IEnumerator CoShoot()
    {
        while (shovels.Count < Data.count)
        {
            Shovel shovel = CreateNewWeapon() as Shovel;
            weapon = shovel;
            shovel.SetDamage(Data.attack);
            shovels.Add(shovel);
        }

        currentElapsedTime += Time.deltaTime;

        float angleUnit = ANGLE / Data.count;

        float angle = 0;
        if (isEven)
        {
            float angleMod = angleUnit * 0.5f;
            for (int i = 0; i < Data.count; i++)
            {
                angle = angleUnit * i + angleMod;
                if (angle >= ANGLE)
                    angle -= ANGLE;

                SetShovelState(angle, i);
            }
        }
        else
        {
            for (int i = 0; i < Data.count; i++)
            {
                angle = angleUnit * i;
                SetShovelState(angle, i);
            }
        }

        isEven = !isEven;


        yield return CoroutineRef.GetWaitForSeconds(timePerAttack);
        StartCoroutine(CoShoot());
    }

    private void SetShovelState(float angle, int i)
    {
        shovels[i].gameObject.SetActive(true);
        shovels[i].transform.position = transform.position;
        shovels[i].transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }

    protected override void Apply()
    {
        Data.count += (int)upgradeValue;
    }
}
