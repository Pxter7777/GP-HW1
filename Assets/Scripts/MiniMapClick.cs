using UnityEngine;

public class MiniMapClick : MonoBehaviour
{
    public Camera miniMapCamera; // The camera rendering the mini map

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//剛好是全屏的，不需要處理
        {
            Ray ray = miniMapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Do something with the hit object
                Debug.Log("Hit: " + hit.collider.gameObject.name);
            }
        }
    }
}