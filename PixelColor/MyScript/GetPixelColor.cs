using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 得到像素点的颜色信息
/// </summary>
public class GetPixelColor : MonoBehaviour
{
    [Tooltip("想得到哪个物体的图片像素")]
    public GameObject obj;
    [Tooltip("用于显示得到像素的颜色在编辑器上")]
    public Color color;

    private Texture2D texture;

    void Start()
    {
        //得到这个物体材质的贴图
        texture = obj.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                //在碰撞位置处的UV纹理坐标
                Vector2 pixelUV = hit.textureCoord;

                //以像素为单位的纹理宽度
                pixelUV.x *= texture.width;
                pixelUV.y *= texture.height;

                color = texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
            }
        }
    }
}