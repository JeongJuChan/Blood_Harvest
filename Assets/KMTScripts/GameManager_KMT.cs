using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_KMT : MonoBehaviour
{
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject GameOverImage;

    private void Update()
    {
        if(GameOverImage.activeSelf)
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
