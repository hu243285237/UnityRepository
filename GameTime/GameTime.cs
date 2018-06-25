using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏运行时间
/// </summary>
public class GameTime : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;

    void Update() 
    {
        hour = (int)Time.time / 3600;
        minute = (int)(Time.time - hour * 3600) / 60;
        second = (int)Time.time % 60;

        Debug.Log(hour + ":" + minute + ":" + second);
    }
}
