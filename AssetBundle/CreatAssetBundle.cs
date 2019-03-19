using System.Collections;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 创建AssetBundle,此脚本放在Editor文件夹
/// </summary>
public class CreatAssetBundle : Editor
{
    [MenuItem("Assets/Build AssetBundle")]
    static void MyBuild()
    {
        //创建Scene
        string[] levels = { "Assets/MyScene/Electromagnetism.unity" };
        BuildPipeline.BuildPlayer(levels, "AssetBundle/Electromagnetism.ab", BuildTarget.StandaloneWindows64, BuildOptions.BuildAdditionalStreamedScenes);
        
        //打包资源，要在Unity编辑器设置AssetBundle名字
        string path = @"C:\Users\Hu\Desktop";
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        AssetDatabase.Refresh();//刷新编辑器界面
    }
}
