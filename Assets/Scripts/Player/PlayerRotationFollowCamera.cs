using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraLauncher))]
public class PlayerRotationFollowCamera : MonoBehaviour, ICameraControllable
{
    private Transform cam;

    private void Start()
    {
        cam = transform.GetComponentInParent<CameraLauncher>().Cam.transform;
    }

    public void Rotate(Vector2 direction)
    {
        transform.rotation = Quaternion.Euler(0, cam.rotation.eulerAngles.y, 0);
    }
}