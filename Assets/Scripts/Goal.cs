using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        print("HITGOAL");
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Player>().Win();
        }
        //print("Enter Ground");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
