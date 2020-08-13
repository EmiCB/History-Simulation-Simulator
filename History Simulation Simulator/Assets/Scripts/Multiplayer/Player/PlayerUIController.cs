using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerUIController : NetworkBehaviour{
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject infoScreen;
    [SerializeField] private GameObject journal;
    [SerializeField] private GameObject chat;

    [SerializeField] private bool isJournalOpen = false;
    [SerializeField] private bool isChatOpen = false;

    public override void OnStartAuthority() {
        canvas.SetActive(true);
        enabled = true;

        InputManager.Controls.Player.ToggleJournal.performed += ctx => ToggleJournal();
        InputManager.Controls.Player.ToggleChat.performed += ctx => ToggleChat();
        InputManager.Controls.Player.ExitInfoScreen.performed += ctx => ExitInfoScreen();

        InputManager.Add(ActionMapNames.Player);
    }

    [Client]
    private void ToggleJournal() {
        isJournalOpen = !isJournalOpen;

        if (isJournalOpen) {
            journal.gameObject.SetActive(true);
            if (isChatOpen) return;
            // disable player movement & show & unlock cursor
            InputManager.Add(ActionMapNames.Player);
            InputManager.Controls.Player.ToggleJournal.Enable();
            InputManager.Controls.Player.ToggleChat.Enable();
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            journal.gameObject.SetActive(false);
            if (isChatOpen) return;
            // enable player movement & hide & lock cursor to center of screen
            InputManager.Remove(ActionMapNames.Player);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    [Client]
    private void ToggleChat() {
        isChatOpen = !isChatOpen;

        if (isChatOpen) {
            chat.gameObject.SetActive(true);
            if (isJournalOpen) return;
            // disable player movement & show & unlock cursor
            InputManager.Add(ActionMapNames.Player);
            InputManager.Controls.Player.ToggleJournal.Enable();
            InputManager.Controls.Player.ToggleChat.Enable();
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            chat.gameObject.SetActive(false);
            if (isJournalOpen) return;
            // enable player movement & hide & lock cursor to center of screen
            InputManager.Remove(ActionMapNames.Player);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    [Client]
    private void ExitInfoScreen() {
        if (!infoScreen.activeSelf) return;
        infoScreen.SetActive(false);
        InputManager.Remove(ActionMapNames.Player);
    }


    public void OnChatSelected() {
        InputManager.Controls.Player.ToggleChat.Disable();
    }
    public void OnChatDeselected() {
        InputManager.Controls.Player.ToggleChat.Enable();
    }
}
