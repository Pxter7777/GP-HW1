using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;
using TMPro;  // 引入 TextMeshPro 命名空間
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAlive = true;
    MouseLook camera_script;
    PlayerMovement movement_script;
    public UIControl UI_script;
    private bool isPaused = false;
    public int basketballCount = 5;
    public TextMeshProUGUI myText;
    void Start()
    {
        camera_script = transform.Find("Main Camera").GetComponent<MouseLook>();
        movement_script = transform.GetComponent<PlayerMovement>();
        //UI_script = GameObject.Find("UIManager").GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&isAlive)
            Esc();
    }

    public void Die(){
        isAlive = false;
        camera_script.Lock();
        movement_script.Lock();
        UI_script.OpenBoomCanvas();
    }
    public void Win(){
        camera_script.Lock();
        movement_script.Lock();
        UI_script.OpenWinCanvas();
    }
    public void Respawn(int HI){
        /*
        StackTrace stackTrace = new StackTrace();
        StackFrame parentFrame = stackTrace.GetFrame(1); // 1 是調用 MyFunction 的方法的堆棧框架
        MethodBase method = parentFrame.GetMethod();
        
        string methodName = method.Name; // 調用方法的名稱
        string className = method.DeclaringType.ToString(); // 調用方法的類的名稱

        UnityEngine.Debug.Log("Called by " + className + "." + methodName);
        */

        movement_script.MovetoStart();
        
        camera_script.Unlock();
        movement_script.Unlock();
        UI_script.CloseBoomCanvas();
        isAlive = true;
    }
    public void Esc(){
        if(isPaused){
            isPaused = false;
            camera_script.Unlock();
            movement_script.Unlock();
            UI_script.CloseEscCanvas();
        }
        else{
            isPaused = true;
            camera_script.Lock();
            movement_script.Lock();
            UI_script.OpenEscCanvas();
        }
        
    }
    public void UpdateText(string newText)
    {
        myText.text = newText;
    }
    public int GetBallCount(){
        return basketballCount;
    }
    public void DecreaseBallCount(){
        basketballCount--;
        this.UpdateText(basketballCount.ToString());
    }
    public void AddBallCount(){
        basketballCount++;
        this.UpdateText(basketballCount.ToString());
    }
}
