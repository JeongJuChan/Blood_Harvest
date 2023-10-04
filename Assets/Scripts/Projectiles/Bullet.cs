using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float disappearedTime = 5f;

    private float _elapsedTime;
    private Vector2 _direction;

    private float _damage;

    public event Action<Bullet> returnToPoolEvent;

    private void OnEnable()
    {
        _elapsedTime = 0f;
    }

    void Update()
    {
        Move();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamagable>().Damaged(_damage);
        }
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetDirection(Vector2 vec)
    {
        _direction = vec.normalized;
        transform.up = _direction;
    }

    public void UpdateDamage(float damage)
    {
        _damage = damage;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Move()
    {
        if (_elapsedTime > disappearedTime)
        {
            returnToPoolEvent?.Invoke(this);
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }

        Vector2 tempVec = (moveSpeed * Time.deltaTime) * _direction;
        transform.position += new Vector3(tempVec.x, tempVec.y, 0f);
    }

}
