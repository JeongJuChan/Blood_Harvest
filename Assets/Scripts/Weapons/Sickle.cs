using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : Weapon
{
    protected override IEnumerator Move()
    {
        yield return null;
    }


    protected override void OnCollide(Collider2D collision)
    {
    }
}
