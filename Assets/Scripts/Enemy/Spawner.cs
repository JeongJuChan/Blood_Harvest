using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            Spawn();
            timer = 0f;
        }
    }
    public void Spawn()
    {
        GameObject enemy = GameManager.instance.mob.GetEnemy(Random.Range(0, 2));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;     // 위에서 GetComponentsInChildren 로 받아왔기 때문에 0번은 자기자신이라 1부터 시작
    }
}
