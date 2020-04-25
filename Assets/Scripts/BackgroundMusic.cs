﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }
}
