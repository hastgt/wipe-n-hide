using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed = 10f;
    //public float _rotationSpeed = 10f;
    bool isColliding = false;

    public Animator animator;
    AudioManager audioManager;

    float walkSoundTimer = 0;
    public float walkSoundTime = 0.3f;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Move", Input.GetAxis("Horizontal"));
        //animator.SetFloat("Move", Input.GetAxis("Vertical"));
        bool isMoving = Movement();
        walkSoundTimer += Time.deltaTime;
        if(walkSoundTimer > walkSoundTime)
        {
            walkSoundTimer = 0;
            if (isMoving)
            {
                audioManager.Play("Walking");
            }
        }
    }


    private bool Movement()
    {
        animator.SetBool("isPressed", false);
        bool isMoving = false;
       
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            animator.SetBool("isPressed", true);
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            animator.SetBool("isPressed", true);
            transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
       
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            animator.SetBool("isPressed", true);
            transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
        }
       
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            animator.SetBool("isPressed", true);
            transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
        }
       

        //float moveVertical = Input.GetAxis("Vertical") * _moveSpeed;
        //moveVertical *= Time.deltaTime;
        //transform.Translate(0, moveVertical, 0);
        //float rotate = Input.GetAxis("Horizontal") * _rotationSpeed;
        //rotate *= Time.deltaTime;
        //transform.Rotate(0, 0, rotate);

        Vector2 lookatCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(lookatCamera.normalized.y, lookatCamera.normalized.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

        return isMoving;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
