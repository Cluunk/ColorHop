using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ResetScore();
    }
    
    public void LoadScene(string scene)
    {
        GameManager.Instance.LoadLevel(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
