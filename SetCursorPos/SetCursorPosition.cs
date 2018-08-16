using UnityEngine;

/// <summary>
/// 强制设置鼠标位置
/// </summary>
public class SetCursorPosition : MonoBehaviour
{

    [System.Runtime.InteropServices.DllImport("user32.dll")]

    public static extern int SetCursorPos(int x, int y);

    void Start()
    {
        SetCursorPos(1920, 1080);
    }
}