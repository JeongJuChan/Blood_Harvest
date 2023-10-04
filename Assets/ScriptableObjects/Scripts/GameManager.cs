using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MobManager mob;
    public Player player;

    public float gameTime;
    public float maxGameTime = 10 * 60.0f;

    private void Awake()
    {
        instance = this;
        GameOverSc.Instance.ResumeGame();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            FreezeGame();
        }
        if(player.GetComponent<CharacterStats>().currentHealth <= 0)
        {
            GameOverSc.Instance.GameOver();
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
