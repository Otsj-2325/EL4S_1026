using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScreen : MonoBehaviour
{
    public void GoNextLevel()
    {
        AsyncOperation operation = new AsyncOperation();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else
        {
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        operation.allowSceneActivation = true;
    }

    public void Replay()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        operation.allowSceneActivation = true;
    }
}
