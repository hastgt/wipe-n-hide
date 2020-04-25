using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed = 10f;
    public float _rotationSpeed = 10f;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Move", Input.GetAxis("Horizontal"));
        animator.SetFloat("Move", Input.GetAxis("Vertical"));
        Movement();
    }

    private void Movement()
    {
        float moveVertical = Input.GetAxis("Vertical") * _moveSpeed;
        moveVertical *= Time.deltaTime;
        transform.Translate(0, moveVertical, 0);
        //float rotate = Input.GetAxis("Horizontal") * _rotationSpeed;
        //rotate *= Time.deltaTime;
        //transform.Rotate(0, 0, rotate);

        Vector2 lookatCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(lookatCamera.normalized.y, lookatCamera.normalized.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
    }
}
