using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MobManager mob;
    public TestPlayer player;

    private void Awake()
    {
        instance = this;
    }
}
