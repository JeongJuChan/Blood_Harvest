using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossBullet : MonoBehaviour
{
    public Rigidbody2D target;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        Vector2 bossBulletDir = target.transform.position - transform.position;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 1);
        gameObject.GetComponent<Rigidbody2D>().AddForce(bossBulletDir.normalized * 400.0f * Time.deltaTime, ForceMode2D.Impulse);

        Destroy(gameObject, 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            // 플레이어의 체력을 더 많이 깎고
            Destroy(gameObject);
        }
    }
}
