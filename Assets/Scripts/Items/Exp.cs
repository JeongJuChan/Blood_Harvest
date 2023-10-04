using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int expAmount;
    private CharacterStatsHandler stats;
    private GameObject player;
    public bool magnetTime = false;

    private void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStatsHandler>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stats.ExpUp(expAmount);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (magnetTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 20 * Time.deltaTime);
        }
    }
}
