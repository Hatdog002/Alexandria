using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public KeyCode key = KeyCode.Tab; // Which key should trigger the fade?
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;


    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }
    public void FadeOut()
    {
        if (direction == 0) // Only execute if not already fading
        {
            
                alpha = 0f; // Start with fully visible
                time = 1f; // Start time at max
                direction = -1; // Set direction to fade out
            
         
        }
    }

    public void FadeIn()
    {
        if (direction == 0) // Only execute if not already fading
        {
            
                alpha = 1f; // Start with fully transparent
                time = 0f; // Start time at min
                direction = 1; // Set direction to fade in
            
           
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }
}