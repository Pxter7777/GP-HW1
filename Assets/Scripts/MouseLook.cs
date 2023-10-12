using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 2.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private bool moveable = true;
    public GameObject BasketballPrefab;
    private Player playerScript;
    void Start()
    {
        playerScript = transform.parent.GetComponent<Player>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(!moveable)
            return;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -90, 90);
        
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.localRotation = Quaternion.Euler(0, rotationY, 0);
        if (Input.GetMouseButtonDown(0))
            ShootBasketball();
    }
    void ShootBasketball(){
        if(playerScript.GetBallCount()>0){
            GameObject ball = Instantiate(BasketballPrefab, transform.position+transform.forward*0.5f, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = transform.forward*6.0f+transform.parent.GetComponent<Rigidbody>().velocity*0.7f;
            playerScript.DecreaseBallCount();//todo
        }
        
    }
    public void Lock(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        moveable = false;
    }
    public void Unlock(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //print("SHOULDNOTBEVISIBLE");
        moveable = true;
    }
}