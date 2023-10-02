using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelShooter : Shooter
{
    private const int ANGLE = 360;
    bool isEven = false;

    private List<Shovel> shovels = new List<Shovel>();

    protected override IEnumerator Shoot()
    {
        while (shovels.Count < Data.count)
        {
            Shovel shovel = CreateNewWeapon() as Shovel;
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
        StartCoroutine(Shoot());
    }

    private void SetShovelState(float angle, int i)
    {
        shovels[i].gameObject.SetActive(true);
        shovels[i].transform.position = transform.position;
        shovels[i].transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
