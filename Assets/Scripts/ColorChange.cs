using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public float cycleSpeed = 0.5f;
    public float offset = 0f;

    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        float hue = (Time.time * cycleSpeed) % 1;
        img.color = Color.HSVToRGB(hue, 0.8f, 0.8f);
    }
}
