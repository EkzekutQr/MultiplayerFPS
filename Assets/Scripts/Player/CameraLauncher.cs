using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PlayerRotationFollowCamera))]
public class CameraLauncher : MonoBehaviour, IPlayerCameraHolder
{
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject cinemachinePrefab;

    [SerializeField] private GameObject cameraFollow;

    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject cinemachine;

    public GameObject Cam { get => cam; }


    private void Awake()
    {
        if (!gameObject.GetPhotonView().IsMine) return;

        InstantiateCamera();
        InstantiateCinemachine();
        cinemachine.GetComponent<CinemachineCamera>().Follow = cameraFollow.transform;
    }

    private void InstantiateCamera()
    {
        cam = Instantiate(cameraPrefab, cameraPrefab.transform.position, Quaternion.identity, null);
    }

    private void InstantiateCinemachine()
    {
        cinemachine = Instantiate(cinemachinePrefab, cinemachinePrefab.transform.position, Quaternion.identity, null);
    }

    private void OnDestroy()
    {
        Destroy(cam);
        Destroy(cinemachine);
    }
}
public interface IPlayerCameraHolder
{
    public GameObject Cam { get; }
}
