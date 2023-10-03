using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;
    int level;
    private bool _isBoss1;
    private bool _isBoss2;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        _isBoss1 = false;
        _isBoss2 = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 2f);

        if (timer > 0.5f)
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
            case 0:     // 1번 근접몹
                enemy.GetComponent<Enemy>().Init(spawnData[0]);
                break;
            case 1:     // 1번 근접몹 + 2번 근접몹
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 2)]);
                break;
            case 2:     // 1번 근접몹 + 2번 근접몹 + 3번 원거리몹
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 3:     // 2번 근접몹 + 3번 원거리몹
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(1, 3)]);
                break;
            case 4:     // 4번 보스몹 1마리 + 1번 근접몹 + 2번 근접몹 + 3번 원거리몹
                if (!_isBoss1)
                {
                    enemy.GetComponent<Enemy>().Init(spawnData[3]);
                    _isBoss1 = true;
                }
                else enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 5:     // 강해진 2번 근접몹
                enemy.GetComponent<Enemy>().Init(spawnData[6]);
                break;
            case 6:     // 강해진 3번 원거리몹
                enemy.GetComponent<Enemy>().Init(spawnData[7]);
                break;
            case 7:     // 강해진 1번 근접몹 + 강해진 3번 원거리몹
                int i = Random.Range(0, 4);
                if (i == 0) enemy.GetComponent<Enemy>().Init(spawnData[7]);
                else enemy.GetComponent<Enemy>().Init(spawnData[5]);
                break;
            case 8:     // 강해진 1번 근접몹 + 강해진 2번 근접몹 + 강해진 3번 원거리몹
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(5, 8)]);
                break;
            case 9:     // 5번 보스몹 1마리 + 강해진 2번 근접몹 + 강해진 3번 원거리몹
                if (!_isBoss2)
                {
                    enemy.GetComponent<Enemy>().Init(spawnData[4]);
                    _isBoss2 = true;
                }
                else enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(6, 8)]);
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
    public int zombieExp;
}