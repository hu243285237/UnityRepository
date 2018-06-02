using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物体沿指定路线移动
/// </summary>
public class MoveAlongWithRoute : MonoBehaviour 
{
    public Transform moveObject;                    //哪个物体移动

    public float speed = 5;                         //移动的速度

    public static Transform[] routeArray;           //路线数组

    private int i = 0;                              //当前移动到哪个节点

	void Start () 
    {
        routeArray = this.gameObject.GetComponentsInChildren<Transform>();//会包含父物体

        moveObject.position = routeArray[0].position;
	}

    //---------------------------------------------------------------------

    void Update()
    {
        moveObject.position = Vector3.MoveTowards(moveObject.position, routeArray[i].position, speed * Time.deltaTime);

        if (moveObject.position == routeArray[i].position)
        {
            i++;

            if (i == routeArray.Length)
            {
                i = 0;
            }
        }
    }

    //---------------------------------------------------------------------
}
