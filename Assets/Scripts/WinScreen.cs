using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class WinScreen : MonoBehaviour
{
    private bool pressWin;
    public GameObject winCan;

    private void Update()
    {
        if(pressWin = true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("u won");
            winCan.SetActive(true);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressWin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressWin = false;
        }
    }
}
