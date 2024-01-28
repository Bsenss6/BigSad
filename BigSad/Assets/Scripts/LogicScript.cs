using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicScript : MonoBehaviour
{

    public int missCount = 0;
    public int perfectCount = 0;

    private static LogicScript instance;


    public void addMiss()
    {
        missCount += 1;
    }

    public void addPerfect()
    {
        perfectCount += 1;
    }

    // 跨Scene时不销毁实例
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
