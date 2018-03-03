# UnityRepository

This repository reserve some frequently-used function in Unity.

Now include function:

1.AsyncLoading

This function can help your make a progress bar.

First,creat a new scene as your loading scene,and creat one UGUI Slider as your progress bar,then hang it AsyncLoadingScene.cs to your any GameObject,drag the slider to script public value position in the end. 

2.BackgroundAudioPlay

This script can continued play background audio in load scene to scene.

Hand it script to a GameOject which should be set DontDestroyOnLoad,secondly drag your music you want to play.

3.DontDestroyOnLoad

This script can make GameObject dont destroy when load next scene,and avoid repeat creat GameObject.

Hang it script to a empty GameObject,and drag what you want to save in load scene. 
