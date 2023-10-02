using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;

    public float playerHealth;
    public float maxplayerHealth = 100;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerHealth = maxplayerHealth;
    }
}
