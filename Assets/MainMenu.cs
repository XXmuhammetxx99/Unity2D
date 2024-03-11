using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("DungeonEscape");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
