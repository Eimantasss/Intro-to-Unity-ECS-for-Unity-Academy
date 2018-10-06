using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceStats : MonoBehaviour
{
    public UnityEngine.UI.Text LabelFrameTime;
    public UnityEngine.UI.Text LabelFramesPerSecond;

    int FrameRate;
    float CpuTime;

    int _Frames;
    float _Time;

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        _Time = Time.unscaledTime;
        _Frames = Time.frameCount;
    }

    void Update()
    {
        var difference = Time.unscaledTime - _Time;
        if (difference >= 1.0f)
        {
            FrameRate = Time.frameCount - _Frames;
            CpuTime = (difference / FrameRate) * 1000;

            LabelFramesPerSecond.text = string.Format("{0} fps", FrameRate);
            LabelFrameTime.text = string.Format("{0:F2} ms", CpuTime);

            Reset();
        }
    }
}
