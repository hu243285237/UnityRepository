using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 加载AssetBundle
/// </summary>
public class LoadAssetBundle : MonoBehaviour
{
    private string url;

    private string assetName;

    void Start()
    {
        url = "file://" + Application.dataPath + "/AssetBundle/Electromagnetism.ab";

        assetName = "Electromagnetism";

        StartCoroutine(DownLoad());
    }

    IEnumerator DownLoad()
    {
        WWW www = new WWW(url);
        yield return www;

        if (!www.isDone)
        {
            Debug.Log("下载失败，错误信息：" + www.error);
        }
        else
        {
            Debug.Log("下载成功");

            AssetBundle bundle = www.assetBundle;

            SceneManager.LoadScene(assetName);

            //如果不"//"这句代码,场景有可能会无法加载
            //bundle.Unload(false);
        }

        //处理掉正在加载过程中的www
        www.Dispose();
    }
}