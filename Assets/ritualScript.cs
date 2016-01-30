using UnityEngine;
using System.Collections;

public class ritualScript : MonoBehaviour {

    public GameObject pentagram;
    public GameObject psycoimg;
    public GameObject fadeInText;
    public GameObject[] candels;
    
    private int candelCounter;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        candelCounter = 0;

        foreach (var candel in candels)
        {
            if (candel.activeSelf)
            {
                candelCounter++;
            }
        }

        if (candelCounter == 5)
        {
            pentagram.SetActive(true);
            psycoimg.SetActive(true);
            StartCoroutine(FadeOut());
        }
	}

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3);
        fadeInText.SetActive(true);
        Animator fadeAnim = GameObject.Find("FadeImage").GetComponent<Animator>();
        fadeAnim.Play("fadeToBlack");
        yield return new WaitForSeconds(1);
        //if (targetSceneName != string.Empty)
        //{
        //    PlayerPrefs.SetString("startPoint", targetSceneStartPoint);
        //    SceneManager.LoadScene(targetSceneName);
        //}
    }
}
