using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetipBigMapCamPos : MonoBehaviour
{
    // Start is called before the first frame update
    LevelGenerator levelScript;
    void Start()
    {
        levelScript = transform.parent.GetComponent<LevelGenerator>();
        transform.position = new Vector3(transform.parent.position.x+levelScript.mazeWidth, 20.0f, transform.parent.position.y+levelScript.mazeHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
