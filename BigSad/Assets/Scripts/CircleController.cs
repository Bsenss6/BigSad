using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float initialScale = 2f;  // Initial zoom size
    public float shrinkTime = 0.1f; // Time required to reduce

    public Animator noteEffect;

    private float rewardAppearTime = 0f; // Finished time

    private bool isClicked = false;
    private bool isShrinking = false;

    public GameObject circleManager;

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
        if (noteEffect == null)
        {
            Destroy(circleManager);
            return;
        }

        if (!isShrinking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                float clickTime = Time.time;

                // 在正负75毫秒的时间范围内触发奖励或失败动画
                if (Mathf.Abs(clickTime - GetAnimationEndTime()) <= 0.075f)
                {
                    TriggerRewardAnimation();
                }
                else
                {
                    TriggerFailAnimation();
                }
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
        noteEffect.SetTrigger("miss");
    }

    public void TriggerRewardAnimation()
    {
        // 触发奖励动画的逻辑，可以在这里播放绿色的奖励动画
        noteEffect.SetTrigger("perfect");
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

    float GetAnimationEndTime()
    {
        // 返回动画结束的时间
        // 这里需要根据你的具体情况实现，可能是根据动画的播放时长来计算
        return 0f; // 需要替换为实际的结束时间
    }
}
