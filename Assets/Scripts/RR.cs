using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RR : MonoBehaviour
{
    // Start is called before the first frame update
    public float Rot=2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(Rot, 0, 0);
    }
}
