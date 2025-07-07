using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CameraLauncher))]
public class PlayerRotationFollowCamera : MonoBehaviour, ICameraControllable
{
    private Transform cam;

    private void Start()
    {
        if (!gameObject.GetPhotonView().IsMine) return;

        cam = transform.GetComponent<CameraLauncher>().Cam.transform;
    }

    public void Rotate(Vector2 direction)
    {
        if (cam == null) return;
        transform.rotation = Quaternion.Euler(0, cam.rotation.eulerAngles.y, 0);
    }
}
