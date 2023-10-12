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
    private bool showing_canvas = false;
    private bool showing_bigmap = false;

    public Camera miniMapCamera;
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
        if(Input.GetKeyDown(KeyCode.M)&&isAlive)
            BigMap();
        if (Input.GetMouseButtonDown(0)&&showing_bigmap)
            ClickMinimap(false);
        if (Input.GetMouseButtonDown(1)&&showing_bigmap)
            ClickMinimap(true);
    }
    void ClickMinimap(bool is_right){
        //剛好是全屏的，不需要處理大地圖相對位置
        Ray ray = miniMapCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject clicked_object;
        if (Physics.Raycast(ray, out hit))
        {
            clicked_object = hit.collider.gameObject;
            if(clicked_object.CompareTag("Ground")){
                if(!is_right)
                    clicked_object.GetComponent<MineGrid>().LeftClicked();//todo
                else if(is_right)
                    clicked_object.GetComponent<MineGrid>().RightClicked();//todo
            }
                
            // Do something with the hit object
            //print("Hit: " + hit.collider.gameObject.name);
        }

    }
    public void Die(){
        isAlive = false;
        
        camera_script.Lock();
        movement_script.Lock();
        UI_script.OpenBoomCanvas();
        showing_canvas = true;
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
        showing_canvas = false;
    }
    public void Esc(){
        if(!showing_canvas&&!isPaused){
            isPaused = true;
            showing_canvas = true;
            camera_script.Lock();
            movement_script.Lock();
            UI_script.OpenEscCanvas();
        }
        else if(showing_canvas&&isPaused){
            
            camera_script.Unlock();
            movement_script.Unlock();
            UI_script.CloseEscCanvas();
            isPaused = false;
            showing_canvas = false;
        }
    }
    public void BigMap(){
        if(!showing_canvas&&!showing_bigmap){
            showing_canvas = true;
            showing_bigmap = true;
            camera_script.Lock();
            movement_script.Lock();
            UI_script.OpenBigMapCanvas();//todo
        }
        else if(showing_canvas&&showing_bigmap){
            camera_script.Unlock();
            movement_script.Unlock();
            UI_script.CloseBigMapCanvas();//todo
            showing_canvas = false;
            showing_bigmap = false;
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
