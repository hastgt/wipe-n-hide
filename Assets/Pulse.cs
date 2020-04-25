using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float timeMultiplier = 3f;

    [Range(0f, 1f)]
    public float amplitude = 0.3f;

    void Update()
    {
        float scale = 1 + amplitude * Mathf.Sin(Time.time * timeMultiplier);
        this.transform.localScale = new Vector3(scale, scale, scale);
    }
}
