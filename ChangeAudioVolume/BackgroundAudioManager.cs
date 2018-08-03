using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 控制背景音乐的管理类
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BackgroundAudioManager : MonoBehaviour
{
    public static BackgroundAudioManager instance;

    //每一个场景对应的背景音乐，在编辑器编辑
    public List<SceneAudio> scenesAudio;

    //是否切换背景音乐
    private bool isChangeAudio = false;

    //当前场景
    private SceneName currentScene;

    //当前播放的audio场景
    private SceneName currentAudioScene;

    //背景音乐AudioSource组件
    private AudioSource backgroundAudioSource;

    //当前场景所有AudioSource，包括预制物体
    AudioSource[] allAudio;

    //已经自带有背景音乐的场景，不通过这个脚本来控制声音
    public SceneName[] selfScene;

    //当前场景除了背景音乐的别的音乐是否正在播放的list
    [HideInInspector]
    public List<int> othersPlayingList = new List<int>();

    //-----------------------------------------------------

    void Start()
    {
        instance = this;

        backgroundAudioSource = this.GetComponent<AudioSource>();

        StartCoroutine(UpdateAudio());
    }

    //-----------------------------------------------------

    IEnumerator UpdateAudio()
    {
        while (true)
        {
            //改变场景时改变背景音乐
            if (currentScene != (SceneName)SceneManager.GetActiveScene().buildIndex)
            {
                currentScene = (SceneName)SceneManager.GetActiveScene().buildIndex;

                //如果当前场景已经自带背景音乐
                foreach (SceneName scene in selfScene)
                {
                    if (currentScene == scene)
                    {
                        currentAudioScene = SceneName.None;
                        backgroundAudioSource.Stop();
                        break;
                    }
                }

                isChangeAudio = (currentAudioScene == currentScene) ? false : true;

                allAudio = null;
                othersPlayingList.Clear();

                //可以找到隐藏的物体，并且会找到预制物体
                allAudio = Resources.FindObjectsOfTypeAll<AudioSource>();

                //找到当前场景所有音乐，给他们添加脚本
                foreach (AudioSource audio in allAudio)
                {
                    //如果这个audio不是预制物体 && 不是背景音乐 && 不是左右摄像机
                    if (audio.gameObject.scene.name != null && audio != backgroundAudioSource && audio.gameObject.name != "Camera R" && audio.gameObject.name != "Camera L")
                    {
                        audio.gameObject.AddComponent<AudioSourceIsPlay>();
                    }
                }
            }

            //切换背景音乐
            if (isChangeAudio)
            {
                foreach (SceneAudio sceneAudio in scenesAudio)
                {
                    if (currentScene == sceneAudio.scene)
                    {
                        backgroundAudioSource.clip = sceneAudio.audio;
                        backgroundAudioSource.Play();

                        currentAudioScene = currentScene;
                    }
                }

                isChangeAudio = false;
            }

            //当有介绍声音或者别的音效时，背景音乐变小
            if (backgroundAudioSource.isPlaying && othersPlayingList.Count > 0)
            {
                if (backgroundAudioSource.volume > 0.26f)
                {
                    backgroundAudioSource.volume = Mathf.Lerp(backgroundAudioSource.volume, 0.25f, 0.25f);
                }
            }
            else 
            {
                if (backgroundAudioSource.volume < 0.99f)
                {
                    backgroundAudioSource.volume = Mathf.Lerp(backgroundAudioSource.volume, 1.0f, 0.25f);
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    //-----------------------------------------------------

    [System.Serializable]
    public struct SceneAudio 
    {
        //实验名字
        public string name;

        //背景音乐
        public AudioClip audio;

        //哪个场景用这个音乐
        public SceneName scene;
    }

    //-----------------------------------------------------
}
