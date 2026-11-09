using UnityEngine;

/// <summary>Displays last-frame FPS and FPS averaged over one-second windows.</summary>
[RequireComponent(typeof(TextMesh))]
public sealed class VRFPSDisplay : MonoBehaviour
{
    private TextMesh label;
    private int windowFrames;
    private double windowSeconds;
    private float displaySeconds;
    private float averageFPS;
    private bool hasAverage;

    private void Awake()
    {
        label = GetComponent<TextMesh>();
    }

    private void OnEnable()
    {
        windowFrames = 0;
        windowSeconds = 0;
        displaySeconds = 0;
        hasAverage = false;
        label.text = "FPS: --\nAvg (1s): --";
    }

    private void Update()
    {
        float dt = Time.unscaledDeltaTime;
        if (dt <= 0f) return;

        windowFrames++;
        windowSeconds += dt;
        displaySeconds += dt;

        // Frames / elapsed time, rather than an arithmetic mean of FPS samples.
        if (windowSeconds >= 1.0)
        {
            averageFPS = (float)(windowFrames / windowSeconds);
            hasAverage = true;
            windowFrames = 0;
            windowSeconds = 0;
        }

        // Refresh text four times per second; instantaneous FPS uses the latest frame.
        if (displaySeconds >= 0.25f)
        {
            string average = hasAverage ? averageFPS.ToString("F1") : "--";
            label.text = $"FPS: {1f / dt:F1}\nAvg (1s): {average}";
            displaySeconds = 0f;
        }
    }
}
