using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCallback : MonoBehaviour
{
    public void destroyObject()
    {
        Debug.Log("destroy me!");
        Destroy(gameObject);
    }
}
