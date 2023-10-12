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
    private bool isBomb = false;
    void Start()
    {
        
    }
    public void ChangeMaterialSafe(){

    }
    public void setStepOnTexture(Texture2D texture){
        this.StepOnTexture = texture;
        GetComponent<Renderer>().material.mainTexture = this.hidTexture;
    }
    public void Step(GameObject stepper){
        if(!isStepped){
            isStepped = true;
            GetComponent<Renderer>().material = Normal;
            GetComponent<Renderer>().material.mainTexture = this.StepOnTexture;
            if(isBomb){
                Instantiate(ExplosionEffectPreFab, transform.position, Quaternion.identity);
                if(stepper.CompareTag("Ball")){
                    Destroy(stepper);
                }
                else if(stepper.CompareTag("Player")){
                    //print(stepper);
                    stepper.GetComponent<Player>().Die();
                }
            }
                
        }
    }
    public void SetupExplosionOrNot(int isBomb){
        if(isBomb==1)
            this.isBomb = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
