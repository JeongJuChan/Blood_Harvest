using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour
{
    [SerializeField] private int spdUpValue;
    [SerializeField] private float buffTime;
    private CharacterStatsHandler stats;

    private void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStatsHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stats.StartCoroutine(stats.SpdBuff(spdUpValue, buffTime));
            gameObject.SetActive(false);
        }
    }
}
