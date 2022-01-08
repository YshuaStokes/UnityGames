using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private bool gameEnded;



    public void WinLevel()
    {
        if (!gameEnded)
        {

            Debug.Log("You Win!");
            //SceneManager.LoadScene(3);
            gameEnded = true;
        }
    }

    public void LoseLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Lose!");
            //SceneManager.LoadScene(2);
            gameEnded = true;
        }

    }
}
