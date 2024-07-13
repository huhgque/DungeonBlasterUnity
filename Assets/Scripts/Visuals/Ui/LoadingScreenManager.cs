using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public event EventHandler<OnLoadingSceneProgressChangeArgs> OnLoadingSceneProgressChange;
    public class OnLoadingSceneProgressChangeArgs:EventArgs{
        public float progress;
    }
    [SerializeField] GameObject loadingScreen;
    void Start(){
        loadingScreen.SetActive(false);
    }
    public void LoadScene(int index){
        StartLoading(index);
    }
    public void LoadScene(string scene){
        StartLoading(scene);
    }
    void StartLoading(string name){
        StartCoroutine(LoadSceneAsync(name)) ;
    }
    void StartLoading(int index){
        StartCoroutine(LoadSceneAsync(index)) ;
    }
    IEnumerator LoadSceneAsync(string sceneName){
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!asyncOperation.isDone){
            float progress = Mathf.Clamp01(asyncOperation.progress);
            OnLoadingSceneProgressChange?.Invoke(this,new OnLoadingSceneProgressChangeArgs{progress = progress});
            yield return null;
        }
    }
    IEnumerator LoadSceneAsync(int sceneIndex){
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!asyncOperation.isDone){
            float progress = Mathf.Clamp01(asyncOperation.progress);
            OnLoadingSceneProgressChange?.Invoke(this,new OnLoadingSceneProgressChangeArgs{progress = progress});
            yield return null;
        }
    }
}
