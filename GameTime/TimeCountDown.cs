using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏倒计时
/// </summary>
public class TimeCountDown : MonoBehaviour
{
    //指定秒数
    public float specifySecond = 100;

    private int hour;
    private int minute;
    private int second;

    //----------------------------------------------------------

    void Update() 
    {
        if(specifySecond >= 0)
        {
            hour = (int)specifySecond / 3600;
            minute = (int)(specifySecond - hour * 3600) / 60;
            second = (int)specifySecond % 60;

            specifySecond -= Time.deltaTime;

            Debug.Log(hour + ":" + minute + ":" + second);
        }
    }

    //----------------------------------------------------------
}
