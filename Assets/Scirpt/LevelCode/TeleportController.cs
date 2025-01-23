using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    // Call this method to teleport the object to the specified position
    public void TeleportToPosition(Vector3 newPosition, Quaternion newRotation)
    {
        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
