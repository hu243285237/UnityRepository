using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeed : MonoBehaviour
{
    void Start()
    {
        //Random.seed已过时,用Random.InitState替代
        Random.InitState(1);

        //如果设置了InitState(也就是seed),每次运行unity都会输出相同的数
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(Random.Range(0, 100));
        }
    }
}