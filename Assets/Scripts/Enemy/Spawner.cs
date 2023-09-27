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
            case 0:     // 1�� ������
                enemy.GetComponent<Enemy>().Init(spawnData[0]);
                break;
            case 1:     // 1�� ������ + 2�� ������
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 2)]);
                break;
            case 2:     // 1�� ������ + 2�� ������ + 3�� ���Ÿ���
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 3:     // 2�� ������ + 3�� ���Ÿ���
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(1, 3)]);
                break;
            case 4:     // 4�� ������ 1���� + 1�� ������ + 2�� ������ + 3�� ���Ÿ���
                if (!_isBoss1)
                {
                    enemy.GetComponent<Enemy>().Init(spawnData[3]);
                    _isBoss1 = true;
                }
                else enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 5:     // ������ 2�� ������
                enemy.GetComponent<Enemy>().Init(spawnData[1]);
                break;
            case 6:     // ������ 3�� ���Ÿ���
                enemy.GetComponent<Enemy>().Init(spawnData[2]);
                break;
            case 7:     // ������ 1�� ������ + ������ 3�� ���Ÿ���

                break;
            case 8:     // ������ 1�� ������ + ������ 2�� ������ + ������ 3�� ���Ÿ���
                enemy.GetComponent<Enemy>().Init(spawnData[Random.Range(0, 3)]);
                break;
            case 9:     // 5�� ������ 1���� + ������ 2�� ������ + ������ 3�� ���Ÿ���
                if (!_isBoss2)
                {
                    enemy.GetComponent<Enemy>().Init(spawnData[4]);
                    _isBoss2 = true;
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