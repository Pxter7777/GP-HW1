using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGrid : MonoBehaviour
{
    // Start is called before the first frame update
    //Renderer rend = gameObject.GetComponent<Renderer>();
    //Material matStep = rend.material;
    //Material matHid = rend.material;
    public Texture2D hidTexture;
    private Texture2D StepOnTexture;
    void Start()
    {
        
    }
    public void setStepOnTexture(Texture2D texture){
        this.StepOnTexture = texture;
        GetComponent<Renderer>().material.mainTexture = this.StepOnTexture;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
