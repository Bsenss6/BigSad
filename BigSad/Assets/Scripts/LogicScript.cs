using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicScript : MonoBehaviour
{

    public int missCount = 0;
    public int perfectCount = 0;
    public Text perfectText;
    public Text missText;

    private static LogicScript instance;


    public void addMiss()
    {
        missCount += 1;
        UpdateText();
    }

    public void addPerfect()
    {
        perfectCount += 1;
        UpdateText();
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

    private void UpdateText()
    {
        if(perfectText != null && missText != null)
        {
            perfectText.text = "perfect : " + perfectCount.ToString();
            missText.text = "miss : " + missCount.ToString();
        }
    }

}
