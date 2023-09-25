using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private static ResourceManager _instance;
    public static ResourceManager Instance { get => GetInstance(); }

    private static ResourceManager GetInstance()
    {
        if (_instance == null)
            _instance = new ResourceManager();

        return _instance;
    }

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
}
