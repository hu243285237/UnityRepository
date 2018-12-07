using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInfo : MonoBehaviour
{
    void Start()
    {
        Debug.Log("主机厂商: " + SystemInfo.deviceModel);

        Debug.Log("主机名称: " + SystemInfo.deviceName);

        Debug.Log("设备类型: " + SystemInfo.deviceType);

        Debug.Log("设备唯一标识符: " + SystemInfo.deviceUniqueIdentifier);

        Debug.Log("显卡唯一标识符: " + SystemInfo.graphicsDeviceID);

        Debug.Log("显卡名称: " + SystemInfo.graphicsDeviceName);

        Debug.Log("显卡类型: " + SystemInfo.graphicsDeviceType);

        Debug.Log("显卡供应商: " + SystemInfo.graphicsDeviceVendor);

        Debug.Log("显卡供应商的唯一识别码: " + SystemInfo.graphicsDeviceVendorID);

        Debug.Log("显卡类型和版本: " + SystemInfo.graphicsDeviceVersion);

        Debug.Log("显存大小: " + SystemInfo.graphicsMemorySize);

        Debug.Log("是否支持多线程渲染: " + SystemInfo.graphicsMultiThreaded);

        Debug.Log("显卡着色器级别: " + SystemInfo.graphicsShaderLevel);

        Debug.Log("支持的最大纹理大小: " + SystemInfo.maxTextureSize);

        Debug.Log("操作系统的版本: " + SystemInfo.operatingSystem);

        Debug.Log("当前处理器的数量: " + SystemInfo.processorCount);

        Debug.Log("处理器的频率: " + SystemInfo.processorFrequency);

        Debug.Log("处理器的名称: " + SystemInfo.processorType);

        Debug.Log("系统内存大小: " + SystemInfo.systemMemorySize);

        Debug.Log("还有很多没写上来");
    }
}
