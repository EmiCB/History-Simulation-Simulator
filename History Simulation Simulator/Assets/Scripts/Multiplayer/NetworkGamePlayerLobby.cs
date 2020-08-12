using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

namespace EmiCB.Lobby {
    public class NetworkGamePlayerLobby : NetworkBehaviour {
        // server validate display name and character data
        [SyncVar]
        public string displayName = "Loading...";
        [SyncVar]
        public CharacterData characterData = null;

        /*
        private bool isHost;
        public bool IsHost {
            set {
                isHost = value;
                startGameButton.gameObject.SetActive(value);
            }
        }
        */

        private NetworkManagerLobby room;
        private NetworkManagerLobby Room {
            get {
                if (room != null) return room;
                return room = NetworkManager.singleton as NetworkManagerLobby;
            }
        }

        // keep player list updated
        public override void OnStartClient() {
            DontDestroyOnLoad(gameObject);
            Room.gamePlayers.Add(this);
        }
        public override void OnNetworkDestroy() {
            Room.gamePlayers.Remove(this);
        }


        [Server]
        public void SetDisplayName(string displayName) {
            this.displayName = displayName;
        }

        [Server]
        public void SetCharacterData(CharacterData characterData) {
            this.characterData = characterData;
        }
    }
}

