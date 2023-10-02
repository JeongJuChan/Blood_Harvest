using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour
{
    [SerializeField] private int spdUpValue;
    [SerializeField] private float buffTime;
    private CharacterStats stats;

    private void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stats.speed += spdUpValue;
            Invoke("EndSpdBuff", buffTime);
            gameObject.SetActive(false);
        }
    }

    private void EndSpdBuff()
    {
        stats.speed -= spdUpValue;
    }
}
