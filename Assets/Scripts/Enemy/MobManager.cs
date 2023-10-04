using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public GameObject[] zombies;

    List<GameObject>[] pools;

    private CharacterStatsHandler _statHandler;

    private void Awake()
    {
        _statHandler = GameManager.instance.player.GetComponent<CharacterStatsHandler>();

        pools = new List<GameObject>[zombies.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetEnemy(int i)
    {
        GameObject zombieSelect = null;

        foreach (GameObject zombie in pools[i])
        {
            if (!zombie.activeSelf)
            {
                zombieSelect = zombie;
                zombieSelect.SetActive(true);
                break;
            }
        }

        if (zombieSelect == null)
        {
            zombieSelect = Instantiate(zombies[i], transform);
            Enemy enemy = zombieSelect.GetComponent<Enemy>();
            enemy.returnToPoolEvent += ReturnToPool;
            pools[i].Add(zombieSelect);
        }

        return zombieSelect;
    }

    private void ReturnToPool(GameObject go)
    {
        go.SetActive(false);
        pools[0].Add(go);
    }
}
