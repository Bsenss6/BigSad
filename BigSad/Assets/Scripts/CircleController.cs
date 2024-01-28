using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float initialScale = 2f;  // Initial zoom size
    public float shrinkTime = 0.2f; // Time required to reduce
    private float rewardAppearTime = 0f; // Finished time

    private bool isClicked = false;
    private bool isShrinking = false;

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
        if (!isShrinking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                // 响应点击事件，可以在这里处理点击后的逻辑
            }

            // 控制圈的缩放
            if (transform.localScale.x > 1f)
            {
                float shrinkSpeed = 1f / shrinkTime;
                transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0) * Time.deltaTime;
            }
            else if (!isClicked)
            {
                // 如果未点击而且圈已经缩小到正常大小，则触发失败动画
                TriggerFailAnimation();
            }
        }
        else
        {
            // 在这里处理奖励动画逻辑
            // 你可以在这里播放奖励动画或者其他操作
        }
    }

    void TriggerFailAnimation()
    {
        // 触发失败动画的逻辑，可以在这里播放红色的失败动画
        Debug.Log("Failed!");
    }

    public void TriggerRewardAnimation()
    {
        // 触发奖励动画的逻辑，可以在这里播放绿色的奖励动画
        Debug.Log("Reward!");
    }

    void OnMouseDown()
    {
        if (!isClicked)
        {
            isClicked = true;
            isShrinking = true;

            // 触发奖励动画的逻辑
            Invoke("TriggerRewardAnimation", rewardAppearTime);
        }
    }
}
