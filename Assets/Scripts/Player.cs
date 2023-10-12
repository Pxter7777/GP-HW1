using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool isAlive = true;
    MouseLook camera_script;
    PlayerMovement movement_script;
    UIControl UI_script;
    
    void Start()
    {
        camera_script = transform.Find("Main Camera").GetComponent<MouseLook>();
        movement_script = transform.GetComponent<PlayerMovement>();
        UI_script = GameObject.Find("UIManager").GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die(){
        //isAlive = false;
        camera_script.Lock();
        movement_script.Lock();
        UI_script.OpenBoomCanvas();
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
        //isAlive = true;
        camera_script.Unlock();
        movement_script.Unlock();
        UI_script.CloseBoomCanvas();
        print("RESPAWN");
    }
}
