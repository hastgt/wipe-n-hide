using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
    public float _speed;
    public bool _moveRight;

  
    // Update is called once per frame
    void Update()
    {
        if (_moveRight)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else if (!_moveRight)
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_moveRight && other.tag == "Paparazzi")
        {
            _moveRight = true;
        }

        else if (_moveRight && other.tag == "Paparazzi")
        {
            _moveRight = false;
        }
    }
}
