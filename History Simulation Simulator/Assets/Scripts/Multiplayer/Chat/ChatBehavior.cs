using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mirror;
using TMPro;

namespace EmiCB.Chat {
    public class ChatBehavior : NetworkBehaviour {
        [SerializeField] private GameObject chatUI = null;
        [SerializeField] private TMP_Text chatText = null;
        [SerializeField] private TMP_InputField inputField = null;

        private static event Action<string> OnMessage;

        // subscribe and unsubscribe to event
        public override void OnStartAuthority() {
            chatUI.SetActive(true);
            OnMessage += HandleNewMessage;
        }
        [ClientCallback]
        private void OnDestroy() {
            if (!hasAuthority) return;
            OnMessage -= HandleNewMessage;
        }

        // add message to chat
        private void HandleNewMessage(string message) {
            chatText.text += message;
        }

        // send message to chat
        [Client]
        public void Send() {
            string message = inputField.text;
            // ensure message is valid
            if (!Input.GetKeyDown(KeyCode.Return)) return;
            if (string.IsNullOrWhiteSpace(message)) return; 

            CmdSendMessage(message);
            inputField.text = string.Empty;
        }

        // format message, where we validate
        [Command]
        private void CmdSendMessage(string message) {
            // TODO: change to be player name
            RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
        }

        // put message on new line 
        [ClientRpc]
        private void RpcHandleMessage(string message) {
            OnMessage?.Invoke($"\n{message}");
        }
    }
}

