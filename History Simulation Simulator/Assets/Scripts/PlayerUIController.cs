using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using EmiCB.Inputs;

public class PlayerUIController : NetworkBehaviour{
    [SerializeField] private Canvas playerUI;

    [SerializeField] private bool isJournalOpen;

    private Controls controls;
    private Controls Controls {
        get {
            if (controls != null) return controls;
            return controls = new Controls();
        }
    }

    public override void OnStartAuthority() {
        enabled = true;

        isJournalOpen = false;
        Controls.Player.ToggleJournal.performed += ctx => ToggleJournal();
    }

    // handle subscriptions, only on client
    [ClientCallback]
    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();

    [Client]
    private void ToggleJournal() {
        isJournalOpen = !isJournalOpen;

        if (isJournalOpen) {
            playerUI.gameObject.SetActive(true);

            // hide & lock cursor to center of screen
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            playerUI.gameObject.SetActive(false);

            // hide & lock cursor to center of screen
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
