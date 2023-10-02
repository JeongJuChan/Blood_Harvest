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
        Time.timeScale = 0f; // �ð��� ������Ŵ
        isPaused = true;

        // ���� �Ͻ� ������ �ʿ��� �߰� �۾� ����
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // �ð��� �ٽ� ������
        isPaused = false;

        // ���� �Ͻ� ���� ������ �ʿ��� �߰� �۾� ����
    }
}
