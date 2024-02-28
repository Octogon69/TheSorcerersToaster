using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
  
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menuscreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ondeath()
    {
        SceneManager.LoadScene("LevelFail");
    }
  
}
