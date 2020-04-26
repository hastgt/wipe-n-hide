using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public float fadeTime = 1f;
    public bool isWon = false;

    public Animator winAnim;
    public Image blackScreen;
    public Text txt;

    private void Awake()
    {
        txt.enabled = false;
    }
    private void WinScr()
    {
        isWon = true;
        StartCoroutine(BlackScreenTransition());
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    IEnumerator BlackScreenTransition()
    {
        float currentAlpha = 0f;
        while (blackScreen.color.a < 1f)
        {
            currentAlpha += Time.deltaTime / fadeTime;
            blackScreen.color = new Color(0f, 0f, 0f, currentAlpha);
            yield return new WaitForEndOfFrame();
        }
        txt.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
        winAnim.SetBool("WON", true);
        WinScr();

        }
    }

}
