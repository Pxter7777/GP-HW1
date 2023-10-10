using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10.0f;
    private bool isGrounded = false;
    private Rigidbody rb;
    public float horizontalDrag = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.fixedDeltaTime = 0.003f;
    }

    void Update()
    {
        // Check for jump input.
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply upward force.
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the collision object has the "Ground" tag and if the collision is below the player and the vertical speed is almost zero.
        if (collision.gameObject.CompareTag("Ground") && IsCollisionBelow(collision) && Mathf.Abs(rb.velocity.y) < 0.5f)
        {
            isGrounded = true;
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            collision.gameObject.GetComponent<MineGrid>().Step();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the collision object has the "Ground" tag.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    bool IsCollisionBelow(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // If there is a contact point below the player, return true.
            if (contact.normal.y > 0.5f) // Adjust this value as needed.
            {
                return true;
            }
        }
        return false;
    }
    void FixedUpdate()
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
        //rb.AddForce(moveDirection * 3.0f);
        rb.velocity = new Vector3(moveDirection.x*4.0f, rb.velocity.y,moveDirection.z*4.0f);
        // 取得水平速度（忽略 Y 軸）
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        // 計算與速度方向相反的阻力
        Vector3 dragForce = -horizontalVelocity * horizontalDrag;

        // 應用阻力
        rb.AddForce(dragForce);
    }
}
