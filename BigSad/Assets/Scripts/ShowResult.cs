using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{

    public Text perfectText;
    public Text missText;
    public LogicScript script;

    // Start is called before the first frame update
    void Start()
    {
        perfectText.text = "perfect : " + script.perfectCount.ToString();
        missText.text = "miss : " + script.missCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
