using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUI : MonoBehaviour
{
    [SerializeField] private Image expSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    private const float LEVEL_DIV = 0.01f;

    private void Start()
    {
        UpdateLevelState(1, 0);
        GameManager.instance.expChangedEvent += UpdateLevelState;
    }

    private void OnDestroy()
    {
        GameManager.instance.expChangedEvent -= UpdateLevelState;
    }

    public void UpdateLevelState(int level, int exp)
    {
        expSlider.fillAmount = exp * LEVEL_DIV;
        levelText.text = $"Level : {level}";
    }
}
