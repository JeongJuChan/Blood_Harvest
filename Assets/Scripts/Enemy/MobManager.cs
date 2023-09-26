using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public GameObject[] zombies;

    List<GameObject>[] pools;

    private void Awake()
    {
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
            pools[i].Add(zombieSelect);
        }

        return zombieSelect;
    }
}
