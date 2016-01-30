using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pauser : MonoBehaviour {

    public GameObject pausePanel;

	private bool paused = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
            TogglePanel(pausePanel);
            paused = !paused;
		}

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
	}

    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

}
