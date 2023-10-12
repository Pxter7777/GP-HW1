using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10.0f;
    private bool isGrounded = false;
    private Rigidbody rb;
    public float horizontalDrag = 2.0f;
    private bool moveable = true;
    Vector3 start_position;
    void Start()
    {
        //starting_transform = transform;
        rb = GetComponent<Rigidbody>();
        Time.fixedDeltaTime = 0.003f;
        start_position = transform.position;
    }

    void Update()
    {
        // Check for jump input.
        if (Input.GetKey(KeyCode.Space))
        {
            if (IsGrounded())
                Jump();
            //else
            //    print("NotOnGround");
        }
    }

    void Jump()
    {
        // Apply upward force.
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    /*void OnCollisionStay(Collision collision)
    {
        // Check if the collision object has the "Ground" tag and if the collision is below the player and the vertical speed is almost zero.
        if (collision.gameObject.CompareTag("Ground") && rb.velocity.y < 1.0f)
        {
            isGrounded = true;
        }
    }*/
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            collision.gameObject.GetComponent<MineGrid>().Step(this.gameObject);
        }
        //print("Enter Ground");
    }
    bool IsGrounded()
    {
        float distanceToGround = 0.51f; // 你可以根據需要調整這個值
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distanceToGround))
        {
            //print("ON GROUND");
            return true;
        }
        //print("NOT GROUND");
        return false;
    }

    /*void OnCollisionExit(Collision collision)
    {
        // Check if the collision object has the "Ground" tag.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //print("Not Ground");
        }
    }*/

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
        if(!moveable)
            return;
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
    public void Lock(){
        moveable = false;
        rb.isKinematic = true;
    }
    public void MovetoStart(){
        transform.position = start_position;
        rb.velocity = Vector3.zero;
    }
    public void Unlock(){
        moveable = true;
        rb.isKinematic = false;
    }
}
