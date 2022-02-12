using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //varables
    public Dictionary<string, string> nextLevel = new Dictionary<string, string>();
    public string StartLevel;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.Add("Tutorial", "Level1");
        nextLevel.Add("Level1", "Level2");
        StartLevel = "Tutorial";
    }

    public void NewGame() { LoadLevel(StartLevel); }
    public void LoadLevel(string level) { SceneManager.LoadScene(level); }
    public void LoadNextLevel() { LoadLevel(nextLevel[SceneManager.GetActiveScene().name]); }
    public void ExitGame() { Application.Quit(); }
}
