using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadGameScene();
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Debug.Log("quit");

        Application.Quit();
    }
}
