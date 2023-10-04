using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSc : MonoBehaviour
{
    public static GameOverSc Instance;
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject GameOverImage;
    [SerializeField] TextMeshProUGUI TimeText;
    float time;
    private void Awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        GameOverImage.SetActive(true);
        if (GameOverImage.activeSelf)
        {
            PauseGame();
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
        SceneManager.LoadScene("GameScene");
        ResumeGame();
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