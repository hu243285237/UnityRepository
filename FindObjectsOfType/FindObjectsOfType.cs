using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectsOfType : MonoBehaviour
{
    void Start()
    {
        //FindObjectsOfType可以找到此场景所有符合这个Type的物体
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in allAudio)
        {
            Debug.Log(audio.name);
        }
    }
}