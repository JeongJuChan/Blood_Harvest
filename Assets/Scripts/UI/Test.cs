using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Button rewardBtn;
    [SerializeField] private Button testBtn;

    public void ShowReward()
    {
        UIManager.Instance.ShowPopup<RewardUI>();
    }

    public void ShowTest()
    {
        UIManager.Instance.ShowPopup<TestUI>();
    }
}

