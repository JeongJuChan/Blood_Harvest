using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePause : MonoBehaviour
{
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}
