using System.Collections;
using UnityEngine;

public class Shovel : Weapon
{
    private bool canMove = false;

    private void OnEnable()
    {
        canMove = true;
    }

    private void OnDisable()
    {
        canMove = false;
    }

    protected override IEnumerator Move()
    {
        while (canMove)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }

    protected override void OnCollide(Collider2D collision)
    {
        base.OnCollide(collision);
    }
}
