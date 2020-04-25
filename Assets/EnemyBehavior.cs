using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float viewAngleInDeg = 45;
    bool lostOnce = false;

    public Sprite camIdle;
    public Sprite camPrimed;

    SpriteRenderer flashSprite;
    AudioSource shutterClick;
    SpriteRenderer camSprite;
    
    private void Awake()
    {
        flashSprite = transform.Find("camera_flash").GetComponent<SpriteRenderer>();
        flashSprite.enabled = false;
        camSprite = GetComponent<SpriteRenderer>();
        shutterClick = GetComponent<AudioSource>();
        // get reference to gamemanager
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Bottom")
        {
            ContactFilter2D contactFilter2D = new ContactFilter2D();
            Vector2 camToPlayer = collision.transform.position - this.transform.position;
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            Physics2D.Raycast(this.transform.position, camToPlayer, contactFilter2D.NoFilter(), hits, camToPlayer.magnitude);

            if (!lostOnce)
            {
                bool insideViewAngle = Mathf.Cos(Mathf.Deg2Rad * viewAngleInDeg) <= Vector2.Dot(camToPlayer.normalized, this.transform.right);
                Debug.DrawRay(this.transform.position, camToPlayer, insideViewAngle ? Color.red : Color.green);
                camSprite.sprite = insideViewAngle ? camPrimed : camIdle;
                
                if (hits[1].collider.tag == "Bottom" && insideViewAngle)
                {
                    lostOnce = true;
                    StartCoroutine(CameraFlash());
                    // tell gamemanager that game is lost
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Bottom")
        {
            camSprite.sprite = camIdle;
        }
    }

    IEnumerator CameraFlash()
    {
        flashSprite.enabled = true;
        shutterClick.Play();
        yield return new WaitForSeconds(0.3f);
        flashSprite.enabled = false;
    }
}
