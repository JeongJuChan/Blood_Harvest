using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUI : MonoBehaviour
{
    [SerializeField] private Image expSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        UpdateLevelState(1, 0, 100);
        GameManager.instance.expChangedEvent += UpdateLevelState;
    }

    private void OnDestroy()
    {
        GameManager.instance.expChangedEvent -= UpdateLevelState;
    }

    public void UpdateLevelState(int level, int exp, int maxExp)
    {
        expSlider.fillAmount = (float)exp / maxExp;
        Debug.Log($"exp : {exp} maxExp : {maxExp}");
        levelText.text = $"Level : {level}";
    }
}
