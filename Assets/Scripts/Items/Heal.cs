using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [Range(1, 100)] public int HealAmount;
    private CharacterStatsHandler stats;

    private void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStatsHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stats.Healing(HealAmount);
            gameObject.SetActive(false);
        }
    }
}
