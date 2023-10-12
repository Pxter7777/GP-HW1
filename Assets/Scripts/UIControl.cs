using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    Canvas boom;
    public Canvas win_canvas;
    void Start()
    {
        boom = GameObject.Find("PlayerStepOnMineScreen").GetComponent<Canvas>();
        boom.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBoomCanvas(){
        boom.enabled=true;
    }
    public void CloseBoomCanvas(){
        boom.enabled=false;
    }
    public void OpenWinCanvas(){
        win_canvas.enabled=true;
    }
    public void CloseWinCanvas(){
        win_canvas.enabled=false;
    }
    public void QuitGame(){
        Application.Quit();
    }
}
