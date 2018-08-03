using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当进入新场景时，这个脚本会添加到每一个拥有AudioSource的物体上，来判断它们是否正在播放声音，以此来控制背景音乐的音量
/// </summary>
public class AudioSourceIsPlay : MonoBehaviour 
{
    //是否正在播放
    private bool playing = false;
    //编号
    private int index;

    //-----------------------------------------------------------------------

    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<AudioSource>() != null && this.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            if (!playing)
            {
                playing = true;

                index = BackgroundAudioManager.instance.othersPlayingList.Count;
                BackgroundAudioManager.instance.othersPlayingList.Add(index);
            }
        }
        else
        {
            if (playing)
            {
                playing = false;

                BackgroundAudioManager.instance.othersPlayingList.Remove(index);
            }
        }
    }

    //-----------------------------------------------------------------------

    void OnDisable() 
    {
        if (playing)
        {
            playing = false;

            BackgroundAudioManager.instance.othersPlayingList.Remove(index);
        }
    }

    //-----------------------------------------------------------------------
}
