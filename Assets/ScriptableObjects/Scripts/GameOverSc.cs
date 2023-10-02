using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSc : MonoBehaviour
{
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject GameOverImage;
    [SerializeField] TextMeshProUGUI TimeText;
    float time;
    public void GameOver()
    {
        GameOverImage.SetActive(true);
        if (GameOverImage.activeSelf)
        {
            SettingButton.SetActive(false);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        TimeText.text = time.ToString("N1");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("KMT_StartScene");
    }
    public void ReStart()
    {
        ResumeGame();
        SceneManager.LoadScene("KMT_GameScene");
    }
    private bool isPaused = false;
    public void PauseGame()
    {
        Time.timeScale = 0f; // 시간을 정지시킴
        isPaused = true;

        // 게임 일시 정지에 필요한 추가 작업 수행
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // 시간을 다시 시작함
        isPaused = false;

        // 게임 일시 정지 해제에 필요한 추가 작업 수행
    }
}
