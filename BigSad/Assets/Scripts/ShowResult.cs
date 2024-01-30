using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{

    public Text perfectText;
    public Text missText;
    public LogicScript logicScript;

    public GameObject happy;
    public GameObject neutral;
    public GameObject sad;

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
                sad.SetActive(true);
                neutral.SetActive(false);
                happy.SetActive(false);
            }
            else if (logicScript.missCount == logicScript.perfectCount)
            {
                sad.SetActive(false);
                neutral.SetActive(true);
                happy.SetActive(false);
            }
            else
            {
                sad.SetActive(false);
                neutral.SetActive(false);
                happy.SetActive(true);
            }

            logicScript.perfectCount = 0;
            logicScript.missCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
