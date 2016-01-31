using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {
    
    public Button startButton;

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeOut()
    {
        Animator fadeAnim = GameObject.Find("FadeImage").GetComponent<Animator>();
        fadeAnim.Play("fadeToBlack");
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetString("startPoint", "leftEntrance");
        SceneManager.LoadScene("Kitchen");
    }
}
