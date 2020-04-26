using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltAround : MonoBehaviour
{
    public float tiltTime = 2f;
    public float tiltDuration = 1f;
    public float tiltAngle = 30f;
    bool isTiltedLeft = true;
    bool isTilting = false;
    float tiltTimer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        tiltTimer += Time.deltaTime;
        if(tiltTimer >= tiltTime + tiltDuration)
        {
            tiltTimer = 0f;
            StartCoroutine(StartTilt());
        }
    }

    IEnumerator StartTilt()
    {
        isTilting = true;
        bool hasReachedLimit = false;

        while (!hasReachedLimit)
        {
            float tiltAngleDir = isTiltedLeft ? 1 : -1;
            transform.localEulerAngles += new Vector3(0, 0, tiltAngleDir * tiltAngle * Time.deltaTime / tiltDuration);

            print((360-transform.localEulerAngles.z) % 360);

            hasReachedLimit = transform.localEulerAngles.z > tiltAngle;
            
            yield return new WaitForEndOfFrame();
        }
        transform.localEulerAngles = new Vector3(0, 0, isTiltedLeft ? tiltAngle : 0f);
        isTiltedLeft = !isTiltedLeft;
        isTilting = false;

    }

}
