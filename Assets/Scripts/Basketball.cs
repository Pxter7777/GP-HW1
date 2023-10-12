using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    // Start is called before the first frame update
    private float shootTime;
    void Start()
    {
        shootTime = Time.time;
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            collision.gameObject.GetComponent<MineGrid>().Step(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanPickUp(){
        return Time.time - shootTime > 1f;
    }
}
