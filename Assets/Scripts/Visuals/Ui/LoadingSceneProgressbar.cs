using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneProgressbar : MonoBehaviour
{
    [SerializeField] LoadingScreenManager loadingScreenManager;
    [SerializeField] Sprite progressDone;
    [SerializeField] List<Image> ProgressImages;
    void Start() {
        loadingScreenManager.OnLoadingSceneProgressChange += OnLoadingSceneProgressChange;
    }
    public void OnLoadingSceneProgressChange(object sender,LoadingScreenManager.OnLoadingSceneProgressChangeArgs args){
        float currentProgress = args.progress * 5;
        for (int i = 0; i < currentProgress; i++)
        {
            ProgressImages[i].sprite = progressDone;
        }
    }
}
