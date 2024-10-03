using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private IControllable controllable;
    private ICameraControllable cameraControllable;
    private IUsingControllable usingControllable;
    private GameInput gameinput;
    private PhotonView photonView;

    public GameInput Gameinput { get => gameinput; set => gameinput = value; }

    private void Awake()
    {
        gameinput = new GameInput();
        gameinput.Enable();
        controllable = GetComponent<IControllable>();
        cameraControllable = transform.GetComponentInChildren<ICameraControllable>();
        usingControllable = GetComponent<IUsingControllable>();
        Debug.Log(cameraControllable == null);
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            Camera cam = transform.GetComponentInChildren<Camera>();
            cam.enabled = false;
            cam.GetComponent<AudioListener>().enabled = false;
        }
    }

    private void OnEnable()
    {
        if (!photonView.IsMine) return;
        gameinput.Gameplay.Jump.performed += OnJumpPerformed;
        gameinput.Gameplay.Using.performed += OnUsingPerformed;
    }

    private void OnDisable()
    {
        if (!photonView.IsMine) return;
        gameinput.Gameplay.Jump.performed -= OnJumpPerformed;
        gameinput.Gameplay.Using.performed -= OnUsingPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        controllable.Jump();
    }
    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        ReadMovement();
        controllable.ApplyVerticalMoving();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = gameinput.Gameplay.Movement.ReadValue<Vector2>();
        controllable.Move(inputDirection);
    }
    private void LateUpdate()
    {
        if (!photonView.IsMine) return;

        ReadRotation();
    }
    private void ReadRotation()
    {
        Vector2 inputRotationDirection = gameinput.Gameplay.Rotation.ReadValue<Vector2>();
        cameraControllable.Rotate(inputRotationDirection);
    }
    private void OnUsingPerformed(InputAction.CallbackContext obj)
    {
        usingControllable.Use();
    }
}
