using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSc : MonoBehaviour
{
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject GameOverImage;
    public void GameOver()
    {
        GameOverImage.SetActive(true);
        if (GameOverImage.activeSelf)
        {
            SettingButton.SetActive(false);
        }
    }
    public void GoHome()
    {
        SceneManager.LoadScene("KMT_StartScene");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("KMT_GameScene");
    }
}
