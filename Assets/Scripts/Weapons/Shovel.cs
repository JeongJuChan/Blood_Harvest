using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    protected override void Move()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime);
    }

    protected override void OnCollide(Collider2D collision)
    {
        // �浹 �� ������ �ֱ�
        //collision.GetComponent<Enemy>().OnDamaged(damage);
        gameObject.SetActive(false);
    }
}
