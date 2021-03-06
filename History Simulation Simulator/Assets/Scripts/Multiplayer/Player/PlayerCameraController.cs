﻿using UnityEngine;
using Mirror;
using Cinemachine;

namespace EmiCB {
    public class PlayerCameraController : NetworkBehaviour {
        [Header("Camera")]
        [SerializeField] private Vector2 maxFollowOffset = new Vector2(-1.0f, 6.0f);
        [SerializeField] private Vector2 cameraVelocity = new Vector2(4.0f, 0.25f);
        [SerializeField] private Transform playerTransform = null;
        [SerializeField] private CinemachineVirtualCamera virtualCamera = null;
        
        private CinemachineTransposer transposer;

        // runs on start if player is ours
        public override void OnStartAuthority() {
            // cache component
            transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            // enable camera for specific player
            virtualCamera.gameObject.SetActive(true);
            // enable this component
            enabled = true;

            // hide & lock cursor to center of screen
            Cursor.lockState = CursorLockMode.Locked;

            // hook up controls
            InputManager.Controls.Player.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
        }

        private void Look(Vector2 lookAxis) {
            float deltaTime = Time.deltaTime;

            // calculate & fix camera offset, perform rotations
            transposer.m_FollowOffset.y = Mathf.Clamp(
                transposer.m_FollowOffset.y - (lookAxis.y * cameraVelocity.y * deltaTime),
                maxFollowOffset.x,
                maxFollowOffset.y
            );
            playerTransform.Rotate(0.0f, lookAxis.x * cameraVelocity.x * deltaTime, 0.0f);
        }
    }
}

