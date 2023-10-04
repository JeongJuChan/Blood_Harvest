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

    private void GetBullet()
    {
        if (_bullets.Count > 0)
        {
            Bullet bullet = _bullets.Dequeue();
            _aimDirection = projectileSpownPosition.right;
            bullet.SetPosition(projectileSpownPosition.position);
            bullet.SetDirection(_aimDirection);
            bullet.SetDamage(_statHandler.CurrentStats.damage);
            bullet.gameObject.SetActive(true);
        }
        else
        {
            CreateNewBullet();
            GetBullet();
        }
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
            GetBullet();
            _elapsedTime = 0f;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }
}
