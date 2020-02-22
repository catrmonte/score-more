using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color colorStart = new Vector4(1, 0, 0, 1);
    public Color colorEnd = new Vector4(0, 1, 0, 1);

    public float duration = 3f;

    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(colorStart, colorEnd, lerp);
    }
}
