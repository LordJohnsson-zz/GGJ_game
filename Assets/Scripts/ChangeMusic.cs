using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeMusic : MonoBehaviour {

    public AudioClip nextMusic;
    public int levelIndex;

    private AudioSource source;


    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnLevelWasLoaded(int level)
    {
    
        if (level == levelIndex)
        {
            source.clip = nextMusic;
            source.Play();
        }

    }
}
