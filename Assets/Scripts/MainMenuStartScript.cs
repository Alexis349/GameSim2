using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartScript : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("BreakRoom");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
