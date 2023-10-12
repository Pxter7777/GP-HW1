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
        transform.position = new Vector3(levelScript.mazeWidth, 20.0f,levelScript.mazeHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
