using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloow : MonoBehaviour
{
    public Transform target;        // Player's transform
    public Vector3 offset;          // Offset from the player
    public float smoothTime = 0.3f; // Smoothing time for camera movement

    private Vector3 velocity = Vector3.zero; // Velocity for SmoothDamp

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the target position including the offset
            Vector3 targetPos = target.position + offset;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }
    }
}
