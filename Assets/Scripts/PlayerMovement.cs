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
        float rotate = Input.GetAxis("Horizontal") * _rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * _moveSpeed;
        rotate *= Time.deltaTime;
        moveVertical *= Time.deltaTime;
        transform.Rotate(0, 0, rotate);
        transform.Translate(0, moveVertical, 0);
    }
}
