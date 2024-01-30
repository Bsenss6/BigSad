using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{

    public Text perfectText;
    public Text missText;
    public LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = FindObjectOfType<LogicScript>();
        Debug.Log($"{logicScript.perfectCount} {logicScript.missCount}");

        if (logicScript != null) {
            perfectText.text = "perfect : " + logicScript.perfectCount.ToString();
            missText.text = "miss : " + logicScript.missCount.ToString();
            logicScript.perfectCount = 0;
            logicScript.missCount = 0;
        }
        else
        {
            Debug.Log("miss logic script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
