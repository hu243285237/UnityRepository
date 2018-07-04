using System.Collections;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 创建AssetBundle,此脚本放在Editor文件夹
/// </summary>
public class CreatAssetBundleScene : Editor
{
    [MenuItem("Assets/Build AssetBundle Scene")]
    static void MyBuild()
    {
        string[] levels = { "Assets/MyScene/Electromagnetism.unity" };

        BuildPipeline.BuildPlayer(levels, "AssetBundle/Electromagnetism.ab", BuildTarget.StandaloneWindows64, BuildOptions.BuildAdditionalStreamedScenes);

        AssetDatabase.Refresh();//刷新编辑器界面
    }
}