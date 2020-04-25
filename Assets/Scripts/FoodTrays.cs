using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrays : MonoBehaviour
{
    private bool _isPickable;
    public Transform food;
    public Transform hands;

    private void Update()
    {
        PickingUp();
    }

    private void PickingUp()
    {
        if (_isPickable = true && Input.GetKey(KeyCode.E))
        {
            food.transform.position = hands.transform.position;
            Vector2 lookatCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotationZ = Mathf.Atan2(lookatCamera.normalized.y, lookatCamera.normalized.x) * Mathf.Rad2Deg;
            food.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("true");
        _isPickable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("false");
        _isPickable = false;
    }
}
