using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {
    
    public void StartGame(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
