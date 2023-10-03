using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private WeaponManager _weapon;
    public WeaponManager Weapon { get => GetInstance(ref _weapon); }


    public MobManager mob;
    public Player player;

    public float gameTime;
    public float maxGameTime = 3 * 10f;

    private CharacterStatsHandler _statsHandler;

    private void Awake()
    {
        instance = this;
        GameOverSc.Instance.ResumeGame();
        _statsHandler = player.GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            FreezeGame();
        }
        if(_statsHandler.CurrentStats.currentHealth <= 0)
        {
            GameOverSc.Instance.GameOver();
        }
    }

    public T GetInstance<T>(ref T t) where T : new()
    {
        if (t == null)
            t = new T();

        return t;
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
