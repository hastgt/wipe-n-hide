using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    PlayerMovement pMove;
    public Image blackScreen;
    public Image loseScreen;
    public Text txtPressToRestart;

    public float fadeTime = 1f;
    public float paperTime = 1f;
    public float rotationSpeed = 720f;
    bool isDead = false;

    public Transform rotator;
    public Animator anim;

    private void Awake()
    {
        if (!IsInMenu())
        {
            pMove = FindObjectOfType<PlayerMovement>();
            txtPressToRestart.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsInMenu()
            || (Input.GetKey(KeyCode.R) && isDead))
        {
            LoadGameScene();
        }
    }

    public void LoseGame()
    {
        pMove.enabled = false;
        isDead = true;
        StartCoroutine(LoseScreenTransition());
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Quit()
    {
        Debug.Log("quit");

        Application.Quit();
    }

    IEnumerator LoseScreenTransition()
    {
        rotator.localEulerAngles = new Vector3(0, 0, Random.Range(-15f, 15f));
        anim.SetTrigger("Newspaper");

        float currentAlpha = 0f;
        while(blackScreen.color.a < 1f)
        {
            currentAlpha += Time.deltaTime / fadeTime;
            blackScreen.color = new Color(0f, 0f, 0f, currentAlpha);
            yield return new WaitForEndOfFrame();
        }

        txtPressToRestart.enabled = true;
    }

    bool IsInMenu()
    {
        return (SceneManager.GetActiveScene().name == "MainMenu");
    }
}
