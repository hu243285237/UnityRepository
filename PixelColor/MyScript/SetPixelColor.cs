using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取模型对应的贴图中的像素点，修改颜色
/// </summary>
public class SetPixelColor : MonoBehaviour
{
    [Tooltip("想修改哪个物体的图片像素")]
    public GameObject obj;
    [Tooltip("点击后像素点的颜色")]
    public Color color;
    [Tooltip("点击后像素点的大小")]
    public int pointSize = 3;

    private Texture2D texture;
    private Color[] textureColors;

    void Start()
    {
        //得到这个物体材质的贴图
        texture = obj.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        //从纹理中获取像素颜色
        textureColors = texture.GetPixels();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //设置颜色
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                //在碰撞位置处的UV纹理坐标
                Vector2 pixelUV = hit.textureCoord;
                //以像素为单位的纹理宽度
                pixelUV.x *= texture.width;
                pixelUV.y *= texture.height;
                //贴图UV坐标以右上角为原点
                for (float i = pixelUV.x - 1; i < pixelUV.x + pointSize; i++)
                {
                    for (float j = pixelUV.y - 1; j < pixelUV.y + pointSize; j++)
                    {
                        texture.SetPixel((int)i, (int)j, color);
                    }
                }
                //会永久改变贴图颜色
                texture.Apply();
            }
        }

        //还原颜色
        if(Input.GetKeyDown(KeyCode.Z))
        {
            texture.SetPixels(textureColors);
            texture.Apply();
        }
    }
}