using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	public static BackgroundMusic instance;
   

    private void Awake()
    {
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			FindObjectOfType<AudioManager>()?.Play("BackgroundMusic");
        }
    }

}
