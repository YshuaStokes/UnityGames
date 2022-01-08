using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YSendMenu : MonoBehaviour
{
    public void replayGame()
    {
        SceneManager.LoadScene(26);
    }

    public void goToMainMenu ()
    {
        SceneManager.LoadScene(25);
    }
}
