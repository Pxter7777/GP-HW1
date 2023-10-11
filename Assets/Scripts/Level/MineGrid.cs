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
    public Material Safe, Normal, Unknown, Danger;
    public GameObject ExplosionEffectPreFab;
    private Texture2D StepOnTexture;

    private bool isStepped = false;
    void Start()
    {
        
    }
    public void ChangeMaterialSafe(){

    }
    public void setStepOnTexture(Texture2D texture){
        this.StepOnTexture = texture;
        GetComponent<Renderer>().material.mainTexture = this.hidTexture;
    }
    public void Step(){
        if(!isStepped){
            isStepped = true;
            GetComponent<Renderer>().material = Normal;
            GetComponent<Renderer>().material.mainTexture = this.StepOnTexture;
            Instantiate(ExplosionEffectPreFab, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
