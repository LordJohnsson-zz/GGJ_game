using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {

    public Slider loadingBar;
    public Button startButton;


    private AsyncOperation async;


    public void ClickStart(int level)
    {
        startButton.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(true);
        StartCoroutine(LoadLevelWithBar(level));
    }


    IEnumerator LoadLevelWithBar(int lvl)
    {
        async = SceneManager.LoadSceneAsync(lvl);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
