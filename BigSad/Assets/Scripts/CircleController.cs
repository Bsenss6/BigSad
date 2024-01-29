using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float initialScale = 2f;  // Initial zoom size
    public LogicScript logicScript;

    public KeyCode keyCode = KeyCode.K;

    public Animator noteEffect;
    public GameObject circleManager;

    private bool isClicked = false;
    private bool isShrinking = true;
    private float playedTime = 0f;
    private float shrinkTime = 0.3f; // Time required to reduce
    private float deviations = 0.3f; // 偏差时间

    void Start()
    {
        // 获取当前缩放大小
        Vector3 currentScale = transform.localScale;

        // 在现有缩放基础上增加 initialScale
        float newScaleX = currentScale.x + initialScale;
        float newScaleY = currentScale.y + initialScale;

        // 设置新的缩放大小
        transform.localScale = new Vector3(newScaleX, newScaleY, 1f);
    }

    void Update()
    {
        playedTime += Time.deltaTime;
        if (noteEffect == null)
        {
            Destroy(circleManager);
            return;
        }

        // 检测键盘按键 keyCode 是否被按下
        if (Input.GetKeyDown(keyCode))
        {
            checkReward();
            isClicked = true;
        }


        // 控制圈的缩放
        if (transform.localScale.x > 1f)
        {
            float shrinkSpeed = 1f / shrinkTime;
            transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0) * Time.deltaTime;
        }

        if (isShrinking)
        {
            if (playedTime > shrinkTime + deviations)
            {
                Debug.Log($"time out shrinkTime {shrinkTime}, playedTime {playedTime}");
                isClicked = true;
                isShrinking = false;
                // 超时
                TriggerFailAnimation();
            }
        }

    }

    void TriggerFailAnimation()
    {
        isClicked = true;
        logicScript.addMiss();
        // 触发失败动画的逻辑，可以在这里播放红色的失败动画
        noteEffect.SetTrigger("miss");
    }

    public void TriggerRewardAnimation()
    {
        logicScript.addPerfect();
        // 触发奖励动画的逻辑，可以在这里播放绿色的奖励动画
        noteEffect.SetTrigger("perfect");
    }

    void OnMouseDown()
    {
        if (!isClicked)
        {
            checkReward();
            isClicked = true;
        }
    }

    void checkReward()
    {
        if (!isClicked)
        {
            isClicked = true;

            Debug.Log($"shrinkTime {shrinkTime}, playedTime {playedTime}");
            // 在正负75毫秒的时间范围内触发奖励或失败动画
            if (Mathf.Abs(shrinkTime - playedTime) <= deviations)
            {
                Debug.Log("reward");
                TriggerRewardAnimation();
            }
            else
            {
                Debug.Log("fail");
                TriggerFailAnimation();
            }
        }
    }
}
