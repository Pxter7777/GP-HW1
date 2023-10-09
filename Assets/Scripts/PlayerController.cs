using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("collide");
        foreach (ContactPoint contact in collision.contacts)
        {
            // contact.normal is the normal of the contact point
            // contact.point is the position of the contact point
            Debug.DrawLine(contact.point, contact.normal*5, Color.red, 2.0f);
            print("DRAW");
        }
    }
}