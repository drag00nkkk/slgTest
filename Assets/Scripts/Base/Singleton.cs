using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : new()
{
    private static T _instance = new T();
    private static readonly object lockObj = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            
            return _instance;
        }
    }
}
