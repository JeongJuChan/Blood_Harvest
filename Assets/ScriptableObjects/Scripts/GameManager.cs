using System;
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
    public float maxGameTime = 10 * 60.0f;

    [SerializeField] private float waitLevelUpClosedTime = 0.5f;

    private CharacterStatsHandler _statsHandler;

    public event Action<int, int, int> expChangedEvent;

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

    public void ShowLevelState(int level, int exp, int maxExp)
    {
        expChangedEvent?.Invoke(level, exp, maxExp);
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

    public void CheckRemainLevelup()
    {
        StartCoroutine(CoCheckLevelupRemained());
    }

    private IEnumerator CoCheckLevelupRemained()
    {
        yield return CoroutineRef.GetWaitForSeconds(waitLevelUpClosedTime);
        _statsHandler.CheckLevelupRemained();
    }
}
