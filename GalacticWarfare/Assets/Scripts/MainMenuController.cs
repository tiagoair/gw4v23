using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void LoadGame()
    {
        GameManager.Instance.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
