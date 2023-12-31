using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    private float _speed;
    private float _health;
    private float _maxHealth;
    private float _attackTimer = 0;
    private float _attackRate = 2.0f;
    private float _bossattackTimer = 0;
    private float _bossattackRate = 0.25f;

    public bool isLive;

    public Rigidbody2D target;
    public RuntimeAnimatorController[] animController;
    public GameObject bulletPrefab;
    public GameObject bossBulletPrefab;
    public ItemDropTable itemDropTable;

    Rigidbody2D rb;
    CapsuleCollider2D cc;
    SpriteRenderer spr;
    Animator anim;

    public event Action<GameObject> returnToPoolEvent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isLive) return;

        Vector2 dir = target.position - rb.position;
        Vector2 nextdir = dir.normalized * _speed * Time.fixedDeltaTime;
        float distance = Vector2.Distance(rb.position, target.position);

        switch (anim.runtimeAnimatorController.name)
        {
            case "AcEnemy 0":
                rb.MovePosition(rb.position + nextdir);
                rb.velocity = Vector2.zero;
                break;
            case "AcEnemy 1":
                rb.MovePosition(rb.position + nextdir);
                rb.velocity = Vector2.zero;
                break;
            case "AcEnemy 2":
                if (distance > 3.0f) rb.MovePosition(rb.position + nextdir);
                else rb.MovePosition(rb.position - nextdir);
                // if (distance < 10.0f)
                // {
                    _attackTimer += Time.deltaTime;
                    if (_attackTimer >= _attackRate)
                    {
                        _attackTimer = 0;
                        GameObject bullet = Instantiate(bulletPrefab, rb.position, Quaternion.identity);
                    }
                // }
                rb.velocity = Vector2.zero;
                break;
            case "AcEnemy 3":
                if (distance < 8.0f) rb.MovePosition(rb.position + (nextdir * 1.5f));
                else rb.MovePosition(rb.position + nextdir);
                rb.velocity = Vector2.zero;
                break;
            case "AcEnemy 4":
                rb.MovePosition(rb.position + nextdir);
                _bossattackTimer += Time.deltaTime;
                if (_bossattackTimer >= _bossattackRate)
                {
                    _bossattackTimer = 0;
                    GameObject bossBullet = Instantiate(bossBulletPrefab, rb.position, Quaternion.identity);
                }
                rb.velocity = Vector2.zero;
                break;
        }          
    }

    private void LateUpdate()
    {
        if (!isLive) return;

        spr.flipX = target.position.x < rb.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        _health = _maxHealth;
    }

    private void OnDestroy()
    {
        returnToPoolEvent = null;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animController[data.zombieType % 5];

        _speed = data.zombieSpeed;
        _maxHealth = data.zombieHealth;
        _health = data.zombieHealth;
    }

    public void Damaged(float damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);

        if (_health > 0)
        {
            anim.SetTrigger("Hit");
        }

        if (_health <= 0f)
        {
            isLive = false;
            cc.isTrigger = true;
            anim.SetBool("Dead", true);
            SoundManager.instance.audioSources[1].Play();
            StartCoroutine(Wait());
            itemDropTable.ItemDrop(transform.position);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        returnToPoolEvent?.Invoke(gameObject);
    }
}
