using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MobManager mob;

    private void Awake()
    {
        instance = this;
    }
}
