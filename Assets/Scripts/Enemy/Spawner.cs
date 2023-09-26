using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;
    int level;
    private bool _isBoss;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        _isBoss = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 6f);

        if (timer > 1f)
        {
            Spawn();
            timer = 0f;
        }
    }

    public void Spawn()
    {
        GameObject enemy = GameManager.instance.mob.GetEnemy(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
        switch (level)
        {
            case 0:
                enemy.GetComponent<Enemy>().Init(spawnData[0]);
                break;
            case 1:
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 2)]);
                break;
            case 2:
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 3:
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(1, 3)]);
                break;
            case 4:
                if (!_isBoss)
                {
                    enemy.GetComponent<Enemy>().Init(spawnData[3]);
                    _isBoss = true;
                }
                else enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(1, 3)]);
                break;
        }
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int zombieType;
    public int zombieHealth;
    public float zombieSpeed;
}