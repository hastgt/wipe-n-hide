using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public float fadeTime = 1f;

    public Animator winAnim;
    public GameObject winCan;
    public Image blackScreen;


    private void WinScr()
    {
        Debug.Log("check");
        
        StartCoroutine(BlackScreenTransition());
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winAnim.SetBool("WON", true);
        WinScr();
    }

}
