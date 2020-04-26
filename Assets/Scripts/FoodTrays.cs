using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodTrays : MonoBehaviour
{
    private bool _isPickable;
    public Transform food;
    public Transform hands;
    public BoxCollider2D useRect;
    bool isWithinBox = true;

    private void Update()
    {
        PickingUp();
    }

    private void PickingUp()
    {
        if (isWithinBox && _isPickable == true && Input.GetMouseButton(0))
        {
            food.transform.position = hands.transform.position;
            Vector2 lookatCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotationZ = Mathf.Atan2(lookatCamera.normalized.y, lookatCamera.normalized.x) * Mathf.Rad2Deg;
            food.rotation = Quaternion.Euler(0f, 0f, hands.transform.eulerAngles.z - 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("true");
            _isPickable = true;
        }
        else if (other == useRect)
        {
            isWithinBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("false");
            _isPickable = false;
        }
        else if (other == useRect)
        {
            isWithinBox = false;
        }
    }
}
