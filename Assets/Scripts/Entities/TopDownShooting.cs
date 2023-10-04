using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private CharacterStatsHandler _statHandler;

    [SerializeField] private Transform projectileSpownPosition;
    [SerializeField] private float shootDelayTime = 1f;
    private float _elapsedTime;

    [SerializeField] private Bullet _bulletSource;

    private Vector2 _aimDirection = Vector2.right;

    private Queue<Bullet> _bullets = new Queue<Bullet>();
    [SerializeField] private int initCount = 10;

    private int _shootingCount = 1;

    [SerializeField] private float angleUnit = 15f;


    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        Init();
    }

    

    void Update()
    {
        Shoot();
    }

    public void UpdateBulletsDamage(float damage)
    {
        foreach (var bullet in _bullets)
        {
            bullet.UpdateDamage(damage);
        } 
    }

    public void DecraseShootingDelay(float decreasingTime)
    {
        shootDelayTime -= decreasingTime;
    }

    public void UpdateShootingCount(int count)
    {
        _shootingCount = count;
    }

    private void Init()
    {
        for (int i = 0; i < initCount; i++)
        {
            CreateNewBullet();
        }
    }

    private void CreateNewBullet()
    {
        Bullet bullet = Instantiate(_bulletSource, projectileSpownPosition.position, Quaternion.identity);
        bullet.SetDirection(_aimDirection);
        bullet.SetDamage(_statHandler.CurrentStats.damage);
        bullet.returnToPoolEvent += ReturnToPool;
        bullet.gameObject.SetActive(false);
        _bullets.Enqueue(bullet);
    }

    private Bullet GetBullet()
    {
        Bullet bullet = null;

        if (_bullets.Count < initCount * 0.5f)
        {
            Init();
        }

        if (_bullets.Count > 0)
        {
            bullet = _bullets.Dequeue();
            
            bullet.SetDamage(_statHandler.CurrentStats.damage);
            bullet.gameObject.SetActive(true);
        }

        return bullet;
    }

    private void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bullets.Enqueue(bullet);
    }

    private void Shoot()
    {
        if (shootDelayTime < _elapsedTime)
        {
            for (int i = 0; i < _shootingCount; i++)
            {
                Bullet bullet = GetBullet();
                bullet.SetPosition(projectileSpownPosition.position);
                float angle = 0f;
                if (_shootingCount % 2 == 0)
                {
                    angle = i % 2 == 0 ? (i + 1) * angleUnit : -(i + 1) * angleUnit;
                }
                else
                {
                    angle = i % 2 == 0 ? i * angleUnit : -i * angleUnit;
                }
                
                _aimDirection = Quaternion.Euler(0, 0, angle) * projectileSpownPosition.right;
                bullet.SetDirection(_aimDirection);
            }
            
            _elapsedTime = 0f;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }
}
