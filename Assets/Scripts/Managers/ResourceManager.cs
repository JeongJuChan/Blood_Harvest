using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
}
