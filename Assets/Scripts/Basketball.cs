using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            collision.gameObject.GetComponent<MineGrid>().Step();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
