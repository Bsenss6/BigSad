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
    public GameObject note;
    public GameObject jack;
    public GameObject king;
    public GameObject lion;
    public Animator jackAnimator;
    public Animator kingAnimator;
    public Animator lionAnimator;
    public LogicScript logic;

    private AnimationEventData[] animationEvents;

    private string easyEvent = "7.384615384615385;j\n11.076923076923077;j\n13.846153846153847;k\n14.76923076923077;j\n15.923076923076923;k\n16.384615384615387;l\n18.461538461538463;j\n19.615384615384617;k\n20.076923076923077;l\n22.153846153846153;l\n23.30769230769231;k\n23.76923076923077;j\n25.846153846153847;l\n27.0;k\n27.461538461538463;j\n29.53846153846154;k\n30.0;l\n30.692307692307693;j\n31.384615384615387;k\n33.23076923076923;k\n33.69230769230769;l\n34.38461538461539;j\n35.53846153846154;k\n36.0;j\n36.46153846153847;l\n36.92307692307693;k\n37.38461538461539;j\n38.07692307692308;l\n38.769230769230774;j\n39.69230769230769;l\n39.92307692307693;k\n40.38461538461539;j\n41.769230769230774;k\n44.30769230769231;j\n44.53846153846154;k\n44.769230769230774;l\n46.15384615384615;k\n48.0;j\n48.23076923076923;k\n48.46153846153847;l\n49.84615384615385;k\n50.307692307692314;l\n50.769230769230774;j\n51.69230769230769;l\n51.92307692307693;k\n52.15384615384615;j\n53.53846153846154;l\n54.46153846153847;j\n54.69230769230769;k\n55.15384615384616;l\n56.53846153846154;k\n57.0;j\n57.23076923076923;l\n58.15384615384616;k\n58.61538461538462;j\n59.07692307692308;l";
    //private string mediumEvent = "1;j\n7.384615384615385;j\n11.076923076923077;j\n13.846153846153847;k\n14.76923076923077;j\n15.923076923076923;k\n16.384615384615387;l\n18.461538461538463;j\n19.615384615384617;k\n20.076923076923077;l\n22.153846153846153;l\n23.30769230769231;k\n23.76923076923077;j\n25.846153846153847;l\n27.0;k\n27.461538461538463;j\n28.615384615384617;k\n29.53846153846154;k\n29.76923076923077;j\n30.0;k\n30.692307692307693;l\n31.384615384615387;l\n33.23076923076923;k\n33.46153846153846;j\n33.69230769230769;k\n34.38461538461539;l\n35.07692307692308;l\n35.53846153846154;j\n36.0;j\n36.46153846153847;j\n36.92307692307693;k\n37.15384615384615;l\n37.38461538461539;k\n38.07692307692308;j\n38.769230769230774;j\n39.69230769230769;k\n39.92307692307693;l\n40.38461538461539;l\n41.769230769230774;k\n42.46153846153847;k\n42.92307692307693;l\n43.38461538461539;k\n43.84615384615385;j\n44.30769230769231;j\n44.53846153846154;k\n44.769230769230774;l\n45.46153846153847;l\n45.69230769230769;k\n45.92307692307693;j\n46.15384615384615;j\n48.0;j\n48.23076923076923;k\n48.46153846153847;l\n49.15384615384615;l\n49.38461538461539;k\n49.61538461538462;j\n49.84615384615385;j\n50.307692307692314;l\n50.769230769230774;k\n51.23076923076923;j\n51.69230769230769;l\n51.92307692307693;k\n52.15384615384615;j\n52.84615384615385;j\n53.07692307692308;k\n53.307692307692314;l\n53.53846153846154;l\n54.0;k\n54.46153846153847;j\n54.69230769230769;k\n55.15384615384616;k\n56.53846153846154;j\n56.769230769230774;k\n57.0;l\n57.23076923076923;k\n57.69230769230769;l\n58.15384615384616;k\n58.61538461538462;j\n59.07692307692308;j";
    //private string hardEvent = "7.384615384615385;j\n8.538461538461538;j\n9.0;k\n11.076923076923077;j\n12.230769230769232;j\n12.692307692307693;l\n13.846153846153847;k\n14.76923076923077;k\n15.923076923076923;k\n16.384615384615387;l\n17.76923076923077;j\n18.461538461538463;k\n19.615384615384617;k\n20.076923076923077;l\n21.461538461538463;j\n22.153846153846153;k\n23.30769230769231;k\n23.76923076923077;j\n25.153846153846157;l\n25.846153846153847;k\n27.0;k\n27.461538461538463;j\n28.615384615384617;k\n29.53846153846154;l\n30.0;k\n30.692307692307693;l\n31.153846153846157;k\n31.846153846153847;j\n32.30769230769231;k\n32.769230769230774;j\n33.23076923076923;l\n33.69230769230769;k\n34.38461538461539;l\n34.84615384615385;k\n35.53846153846154;j\n36.0;l\n36.46153846153847;j\n36.92307692307693;l\n37.38461538461539;k\n37.61538461538462;j\n38.07692307692308;k\n38.53846153846154;j\n39.23076923076923;j\n39.69230769230769;l\n40.15384615384615;j\n40.61538461538462;l\n41.07692307692308;k\n41.30769230769231;j\n41.769230769230774;k\n42.23076923076923;j\n42.46153846153847;l\n43.38461538461539;l\n44.30769230769231;j\n44.53846153846154;k\n44.65384615384615;l\n46.15384615384615;j\n46.38461538461539;k\n46.5;l\n47.53846153846154;k\n48.0;j\n48.23076923076923;k\n48.34615384615385;l\n50.307692307692314;l\n50.769230769230774;k\n51.23076923076923;l\n51.69230769230769;j\n51.92307692307693;k\n52.03846153846154;l\n53.53846153846154;j\n53.769230769230774;k\n53.88461538461539;l\n54.92307692307693;k\n55.38461538461539;j\n55.84615384615385;l\n56.53846153846154;j\n57.0;l\n57.69230769230769;k\n58.15384615384616;j\n58.38461538461539;k\n58.61538461538462;l\n58.84615384615385;k\n59.07692307692308;j";
    //private string expertEvent = "7.384615384615385;j\n8.538461538461538;j\n9.0;k\n11.076923076923077;j\n12.230769230769232;j\n12.692307692307693;l\n13.846153846153847;k\n14.76923076923077;j\n15.230769230769232;k\n15.923076923076923;k\n16.384615384615387;l\n17.076923076923077;k\n17.53846153846154;l\n18.0;k\n18.461538461538463;j\n18.923076923076923;k\n19.615384615384617;k\n20.076923076923077;l\n20.76923076923077;k\n21.230769230769234;j\n21.692307692307693;k\n22.153846153846153;j\n22.615384615384617;k\n22.846153846153847;j\n23.30769230769231;k\n23.76923076923077;l\n24.461538461538463;k\n24.923076923076923;j\n25.384615384615387;k\n25.846153846153847;l\n26.30769230769231;k\n26.53846153846154;j\n27.0;k\n27.461538461538463;l\n27.692307692307693;j\n28.615384615384617;k\n29.53846153846154;j\n29.76923076923077;j\n30.0;j\n30.230769230769234;j\n30.461538461538463;j\n30.692307692307693;j\n30.923076923076923;j\n31.153846153846157;j\n31.384615384615387;k\n31.615384615384617;k\n31.846153846153847;k\n32.07692307692308;k\n32.30769230769231;k\n32.53846153846154;k\n32.769230769230774;k\n33.0;k\n33.23076923076923;l\n33.46153846153846;l\n33.69230769230769;l\n33.92307692307693;l\n34.15384615384615;l\n34.38461538461539;l\n34.61538461538462;l\n34.84615384615385;l\n35.07692307692308;k\n35.53846153846154;l\n36.0;k\n36.46153846153847;j\n36.92307692307693;j\n37.15384615384615;k\n37.269230769230774;l\n38.30769230769231;l\n38.769230769230774;j\n39.0;k\n39.11538461538462;l\n40.15384615384615;l\n40.38461538461539;k\n40.61538461538462;j\n40.84615384615385;k\n41.07692307692308;l\n41.769230769230774;l\n42.23076923076923;k\n42.92307692307693;l\n43.38461538461539;k\n43.61538461538462;l\n43.84615384615385;k\n44.07692307692308;j\n44.30769230769231;l\n44.53846153846154;k\n44.65384615384615;j\n45.46153846153847;l\n45.92307692307693;k\n46.15384615384615;l\n46.38461538461539;k\n46.5;j\n47.307692307692314;k\n47.769230769230774;j\n48.0;l\n48.23076923076923;k\n48.34615384615385;j\n49.15384615384615;l\n49.61538461538462;j\n50.307692307692314;j\n50.769230769230774;k\n51.0;j\n51.23076923076923;k\n51.46153846153847;l\n51.69230769230769;j\n51.92307692307693;k\n52.03846153846154;j\n52.269230769230774;l\n52.38461538461539;j\n52.61538461538462;k\n52.73076923076923;j\n52.96153846153847;l\n53.07692307692308;j\n53.307692307692314;k\n53.53846153846154;l\n53.769230769230774;k\n53.88461538461539;l\n54.11538461538462;j\n54.23076923076923;l\n54.46153846153847;k\n54.69230769230769;j\n54.92307692307693;l\n55.15384615384616;k\n55.38461538461539;j\n55.61538461538462;k\n55.84615384615385;l\n56.53846153846154;l\n57.0;k\n57.69230769230769;j\n57.92307692307693;k\n58.15384615384616;l\n58.38461538461539;k\n58.61538461538462;l\n58.84615384615385;k\n59.07692307692308;j";

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
        animationEvents = ParseStringToAnimationEventDataArray(mediumEvent);
        foreach (AnimationEventData eventData in animationEvents)
        {
            float time = eventData.time-0.3f;
            string targetName = eventData.prefabName;

            // 使用Invoke, 在指定时间调用不同的动画
            Invoke("PlayAnimation_" + targetName , time);
        }
    }

    void PlayAnimation_j()
    {
        GameObject noteInstance = Instantiate(note, jack.transform.position , Quaternion.identity);
        // 设置接收按键
        CircleController circleController = noteInstance.GetComponentInChildren<CircleController>();
        if(circleController != null)
        {
            circleController.keyCode = KeyCode.J;
            circleController.logicScript = logic;
            circleController.actorAnimator = jackAnimator;
        }
    }

    void PlayAnimation_k()
    {
        GameObject noteInstance = Instantiate(note, king.transform.position, Quaternion.identity);
        // 设置接收按键
        CircleController circleController = noteInstance.GetComponentInChildren<CircleController>();
        if (circleController != null)
        {
            circleController.keyCode = KeyCode.K;
            circleController.logicScript = logic;
            circleController.actorAnimator = kingAnimator;
        }
    }

    void PlayAnimation_l()
    {
        GameObject noteInstance = Instantiate(note, lion.transform.position, Quaternion.identity);
        // 设置接收按键
        CircleController circleController = noteInstance.GetComponentInChildren<CircleController>();
        if (circleController != null)
        {
            circleController.keyCode = KeyCode.L;
            circleController.logicScript = logic;
            circleController.actorAnimator = lionAnimator;
        }
    }

    private void OnDestroy()
    {
        // 如果游戏结束，取消所有的Invoke调用
        CancelInvoke();
    }
}
