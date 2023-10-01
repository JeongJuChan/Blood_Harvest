using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private float expAmount;
    private CharacterStats stats;
    private GameObject player;
    public bool magnetTime = false;

    private void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stats.exp += expAmount;
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
