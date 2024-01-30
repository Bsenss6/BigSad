using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{

    public Text perfectText;
    public Text missText;
    public LogicScript logicScript;

    public SpriteRenderer happy;
    public SpriteRenderer neutral;
    public SpriteRenderer sad;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = FindObjectOfType<LogicScript>();
        Debug.Log($"{logicScript.perfectCount} {logicScript.missCount}");

        if (logicScript != null) {
            // set score text
            perfectText.text = "perfect : " + logicScript.perfectCount.ToString();
            missText.text = "miss : " + logicScript.missCount.ToString();
            // set Grade emotions
            if(logicScript.missCount > logicScript.perfectCount)
            {
                sad.enabled = true;
                neutral.enabled = false;
                happy.enabled = false;
            }else if (logicScript.missCount == logicScript.perfectCount)
            {
                sad.enabled = false;
                neutral.enabled = true;
                happy.enabled = false;
            }
            else
            {
                sad.enabled = false;
                neutral.enabled = false;
                happy.enabled = true;
            }

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
