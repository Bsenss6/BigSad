using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventData
{
    public float time;
    public string prefabName;
}


public class AnimationManager : MonoBehaviour
{
    public GameObject music;
    public GameObject jack;
    public GameObject king;
    public GameObject lion;


    private AnimationEventData[] animationEvents;

    private string easyEvent = "7.384615384615385;j\n11.076923076923077;j\n13.846153846153847;k\n14.76923076923077;j\n15.923076923076923;k\n16.384615384615387;l\n18.461538461538463;j\n19.615384615384617;k\n20.076923076923077;l\n22.153846153846153;l\n23.30769230769231;k\n23.76923076923077;j\n25.846153846153847;l\n27.0;k\n27.461538461538463;j\n28.615384615384617;k\n29.53846153846154;k\n29.76923076923077;j\n30.0;k\n30.692307692307693;l\n31.384615384615387;l\n33.23076923076923;k\n33.46153846153846;j\n33.69230769230769;k\n34.38461538461539;l\n35.07692307692308;l\n35.53846153846154;j\n36.0;j\n36.46153846153847;j\n36.92307692307693;k\n37.15384615384615;l\n37.38461538461539;k\n38.07692307692308;j\n38.769230769230774;j\n39.69230769230769;k\n39.92307692307693;l\n40.38461538461539;l\n41.769230769230774;k\n42.46153846153847;k\n42.92307692307693;l\n43.38461538461539;k\n43.84615384615385;j\n44.30769230769231;j\n44.53846153846154;k\n44.769230769230774;l\n45.46153846153847;l\n45.69230769230769;k\n45.92307692307693;j\n46.15384615384615;j\n48.0;j\n48.23076923076923;k\n48.46153846153847;l\n49.15384615384615;l\n49.38461538461539;k\n49.61538461538462;j\n49.84615384615385;j\n50.307692307692314;l\n50.769230769230774;k\n51.23076923076923;j\n51.69230769230769;l\n51.92307692307693;k\n52.15384615384615;j\n52.84615384615385;j\n53.07692307692308;k\n53.307692307692314;l\n53.53846153846154;l\n54.0;k\n54.46153846153847;j\n54.69230769230769;k\n55.15384615384616;k\n56.53846153846154;j\n56.769230769230774;k\n57.0;l\n57.23076923076923;k\n57.69230769230769;l\n58.15384615384616;k\n58.61538461538462;j\n59.07692307692308;j";
    private string mediumEvent = "7.384615384615385;j\n8.538461538461538;j\n9.0;k\n11.076923076923077;j\n12.230769230769232;j\n12.692307692307693;l\n13.846153846153847;k\n14.76923076923077;k\n15.923076923076923;k\n16.384615384615387;l\n17.76923076923077;j\n18.461538461538463;k\n19.615384615384617;k\n20.076923076923077;l\n21.461538461538463;j\n22.153846153846153;k\n23.30769230769231;k\n23.76923076923077;j\n25.153846153846157;l\n25.846153846153847;k\n27.0;k\n27.461538461538463;j\n28.615384615384617;k\n29.53846153846154;l\n30.0;k\n30.692307692307693;k\n31.153846153846157;k\n31.846153846153847;j\n32.30769230769231;l\n32.769230769230774;j\n33.23076923076923;l\n33.69230769230769;k\n34.38461538461539;k\n34.84615384615385;k\n35.53846153846154;k\n36.0;j\n36.46153846153847;k\n36.92307692307693;l\n37.38461538461539;k\n37.61538461538462;j\n38.07692307692308;j\n38.53846153846154;j\n39.23076923076923;l\n39.69230769230769;k\n40.15384615384615;l\n40.61538461538462;l\n41.07692307692308;k\n41.30769230769231;j\n41.769230769230774;j\n42.23076923076923;j\n42.46153846153847;l\n43.38461538461539;k\n44.30769230769231;j\n44.53846153846154;k\n44.65384615384615;l\n46.15384615384615;j\n46.38461538461539;k\n46.5;l\n47.53846153846154;k\n48.0;j\n48.23076923076923;k\n48.34615384615385;l\n50.307692307692314;l\n50.769230769230774;k\n51.23076923076923;l\n51.69230769230769;j\n51.92307692307693;k\n52.03846153846154;l\n53.53846153846154;j\n53.769230769230774;k\n53.88461538461539;l\n54.92307692307693;k\n55.38461538461539;j\n55.84615384615385;l\n56.53846153846154;j\n57.0;l\n57.69230769230769;k\n58.15384615384616;j\n58.38461538461539;k\n58.61538461538462;l\n58.84615384615385;k\n59.07692307692308;j";
    private string testEvents = "1;j\n2;k\n3;l\n4;j\n5;k\n6;l";

    // 将string转换为AnimationEventData[]
    private AnimationEventData[] ParseStringToAnimationEventDataArray(string input)
    {
        List<AnimationEventData> eventDataList = new List<AnimationEventData>();

        string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2)
            {
                AnimationEventData eventData = new AnimationEventData();
                eventData.time = float.Parse(parts[0]);
                eventData.prefabName = parts[1].Trim();
                eventDataList.Add(eventData);
            }
        }

        return eventDataList.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        animationEvents = ParseStringToAnimationEventDataArray(testEvents);
        foreach (AnimationEventData eventData in animationEvents)
        {
            float time = eventData.time;
            string targetName = eventData.prefabName;

            // 使用Invoke, 在指定时间调用不同的动画
            Invoke("PlayAnimation_" + targetName , time);
        }
    }

    void PlayAnimation_j()
    {
        System.DateTime currentTime = System.DateTime.Now;
        string currentTimeString = currentTime.ToString("HH:mm:ss");
        Debug.Log("J Current Time: " + currentTimeString);
    }

    void PlayAnimation_k()
    {
        System.DateTime currentTime = System.DateTime.Now;
        string currentTimeString = currentTime.ToString("HH:mm:ss");
        Debug.Log("K Current Time: " + currentTimeString);
    }

    void PlayAnimation_l()
    {
        System.DateTime currentTime = System.DateTime.Now;
        string currentTimeString = currentTime.ToString("HH:mm:ss");
        Debug.Log("L Current Time: " + currentTimeString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        // 如果游戏结束，取消所有的Invoke调用
        CancelInvoke();
    }
}
