using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using EmiCB.Inputs;

public class PlayerMovementController : NetworkBehaviour {
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private CharacterController controller = null;

    private Vector2 previousInput;

    private Controls controls;
    private Controls Controls {
        get {
            if (controls != null) return controls;
            return controls = new Controls();
        }
    }


    public override void OnStartAuthority() {
        enabled = true;

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }

    // handle subscriptions, only on client
    [ClientCallback]
    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();

    [ClientCallback]
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement) => previousInput = movement;
    [Client]
    private void ResetMovement() => previousInput = Vector2.zero;

    [Client]
    private void Move() {
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.forward;
        right.y = 0.0f;
        forward.y = 0.0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
}
