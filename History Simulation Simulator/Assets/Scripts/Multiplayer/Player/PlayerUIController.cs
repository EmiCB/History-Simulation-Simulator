using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using EmiCB;
using EmiCB.Inputs;

public class PlayerUIController : NetworkBehaviour{
    [SerializeField] private GameObject journal;

    [SerializeField] private bool isJournalOpen = false;

    private Controls controls;
    private Controls Controls {
        get {
            if (controls != null) return controls;
            return controls = new Controls();
        }
    }

    public override void OnStartAuthority() {
        enabled = true;

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
            journal.gameObject.SetActive(true);
            // disable camera movement & hide & lock cursor to center of screen
            // TODO: camera stuff
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            journal.gameObject.SetActive(false);
            // enable camera movement & hide & lock cursor to center of screen
            // TODO: camera stuff
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
