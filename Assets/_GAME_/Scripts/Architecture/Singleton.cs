using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance => _instance;
    private static T _instance;

    private void Awake()
    {
        if (_instance ==null )
        {
            _instance = GetComponent<T>();
        }
        else if (_instance != GetComponent<T>())
        {
            Destroy(gameObject);    
        }
        DontDestroyOnLoad(gameObject);
        
    }
}
