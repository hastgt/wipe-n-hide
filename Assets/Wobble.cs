using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    public float timeMultiplier = 0.5f;
    public float maxAngle = 10f;

    void Update()
    {
        this.transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time * timeMultiplier) * maxAngle);
    }
}
