using UnityEngine;
using System.Collections.Generic;

public class FPSDisplay : MonoBehaviour
{
    public int frameRange = 30;
    private Queue<float> frameTimes = new Queue<float>();
    private float averageFrameTime;
    private int fps;

    void Update()
    {
        // 如果隊列已滿，則移除最舊的元素。
        if (frameTimes.Count == frameRange)
        {
            averageFrameTime -= frameTimes.Dequeue() / frameRange;
        }

        // 添加最新的幀時間到隊列和平均時間。
        frameTimes.Enqueue(Time.unscaledDeltaTime);
        averageFrameTime += Time.unscaledDeltaTime / frameRange;

        // 計算和顯示 FPS。
        fps = Mathf.RoundToInt(1f / averageFrameTime);
    }

    void OnGUI()
    {
        // 設置顯示樣式。
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.UpperRight;

        // 顯示 FPS。
        GUI.Label(new Rect(Screen.width - 100, 10, 90, 30), "FPS: " + fps, style);
    }
}
