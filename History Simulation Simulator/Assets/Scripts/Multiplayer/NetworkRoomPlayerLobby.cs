using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

namespace EmiCB.Lobby {
    public class NetworkRoomPlayerLobby : NetworkBehaviour {
        [Header("UI")]
        [SerializeField] private GameObject lobbyUI = null;
        [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[30];
        [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[30];
        [SerializeField] private Button startGameButton = null;

        // server validate display name changes and ready status changes
        [SyncVar(hook = nameof(HandleDisplayNameChanged))]
        public string displayName = "Loading...";
        [SyncVar(hook = nameof(HandleReadyStatusChanged))]
        public bool isReady = false;

        [SyncVar]
        public CharacterData characterData = null;

        private bool isHost;
        public bool IsHost {
            set {
                isHost = value;
                startGameButton.gameObject.SetActive(value);
            }
        }

        private NetworkManagerLobby room;
        private NetworkManagerLobby Room {
            get {
                if (room != null) return room;
                return room = NetworkManager.singleton as NetworkManagerLobby;
            }
        }

        public override void OnStartAuthority() {
            CmdSetDisplayName(PlayerNameInput.displayName);
            lobbyUI.SetActive(true);
        }

        // keep player list updated
        public override void OnStartClient() {
            Room.roomPlayers.Add(this);
            UpdateDisplay();
        }
        public override void OnNetworkDestroy() {
            Room.roomPlayers.Remove(this);
            UpdateDisplay();
        }

        public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();
        public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();


        // update the UI
        private void UpdateDisplay() {
            // find player that belongs to us before running
            if (!hasAuthority) {
                foreach (var player in Room.roomPlayers) {
                    if (player.hasAuthority) {
                        player.UpdateDisplay();
                        break;
                    }
                }
                return;
            }

            // clear all player texts
            for (int i = 0; i < Room.maxConnections; i++) {
                playerNameTexts[i].text = "Waiting...";
                playerReadyTexts[i].text = string.Empty;
            }

            // update all player texts
            for (int i = 0; i < Room.roomPlayers.Count; i++) {
                playerNameTexts[i].text = Room.roomPlayers[i].displayName;
                playerReadyTexts[i].text = Room.roomPlayers[i].isReady ? "<color=green>Ready</color>" : "<color=red>Not Ready</color>";
            }
        }

        // allow host to start game when everyone is ready
        public void HandleReadyToStart(bool isReadyToStart) {
            if (!isHost) return;
            startGameButton.interactable = isReadyToStart;
        }

        // validate with server
        [Command]
        private void CmdSetDisplayName(string displayName) {
            // add extra validation checks here (ex. banned names)
            this.displayName = displayName;
        }

        [Command]
        public void CmdReadyUp() {
            isReady = !isReady;
            Room.NotifyPlayersOfReadyState();
        }

        [Command]
        public void CmdSetCharacterData(CharacterData characterData) {
            this.characterData = characterData;
        }

        [Command]
        public void CmdStartGame() {
            if (Room.roomPlayers[0].connectionToClient != connectionToClient) return;
            Room.StartGame();
        }
    }
}

