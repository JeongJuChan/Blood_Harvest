using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MobManager mob;
    public Player player;

    public float gameTime;
    public float maxGameTime = 3 * 10f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            Time.timeScale = 0;
        }
    }
}
