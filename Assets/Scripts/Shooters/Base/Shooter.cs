using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public abstract class Shooter : MonoBehaviour
{
    public WeaponData Data { get; protected set; }

    [Header("Shooting Interval")]
    [SerializeField] protected float timePerAttack = 1f;
    private float currentElapsedTime = 0f;

    [Header("Weapon")]
    protected const string WEAPON_PATH = "Weapons/";
    protected Weapon weapon;

    protected void Awake()
    {
         weapon = GetWeapon();
    }

    protected void Start()
    {
        weapon.SetDamage(Data.attack);
    }

    protected void Update()
    {
        if (currentElapsedTime < timePerAttack)
            currentElapsedTime += Time.deltaTime;
        else
        {
            Shoot();
            currentElapsedTime = 0f;
        }
    }

    public void SetData(WeaponData data)
    {
        Data = data;
    }

    protected Weapon GetWeapon()
    {
        string originName = name.Substring(0, name.Length - base.name.Length);
        return Resources.Load<Weapon>($"{WEAPON_PATH}{originName}");
    }

    protected Weapon CreateNewWeapon()
    {
        return Instantiate(weapon.gameObject, transform.position, Quaternion.identity, transform).GetComponent<Weapon>();
    }

    protected abstract void Shoot();
}
