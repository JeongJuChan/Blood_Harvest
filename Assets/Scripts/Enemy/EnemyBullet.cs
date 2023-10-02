using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D target;
    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 255, 1);
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        Vector2 bulletDir = target.transform.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * 300.0f * Time.deltaTime, ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }
}
