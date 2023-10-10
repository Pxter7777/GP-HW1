using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 2.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -90, 90);
        
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.localRotation = Quaternion.Euler(0, rotationY, 0);
    }
}