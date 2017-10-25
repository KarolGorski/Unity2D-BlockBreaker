using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public string name;
    public AudioClip nextLevelSound;

	public void LoadLevel()
    {
        Debug.Log("Level load requested for: " + name);
        Application.LoadLevel(name);
        AudioSource.PlayClipAtPoint(nextLevelSound,new Vector3(0f,0f,0f));
    }
    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
        AudioSource.PlayClipAtPoint(nextLevelSound, new Vector3(0f, 0f, 0f));
    }
    public void Lose()
    {
        Application.LoadLevel("Lose");
    }
}
