using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        // Get input.
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down

        // Calculate movement direction based on player's forward and right vectors.
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * vertical) + (right * horizontal);
        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection.Normalize();
        } 
        // Apply movement.
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
