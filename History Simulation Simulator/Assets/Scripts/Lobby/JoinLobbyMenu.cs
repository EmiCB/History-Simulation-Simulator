using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmiCB.Lobby {
    public class JoinLobbyMenu : MonoBehaviour {
        [SerializeField] private NetworkManagerLobby networkManager = null;

        [Header("UI")]
        [SerializeField] private GameObject landingPagePanel = null;
        [SerializeField] private TMP_InputField ipAddressInputField = null;
        [SerializeField] private Button joinButton = null;

        // know when our client connects & disconnects
        private void OnEnable() {
            NetworkManagerLobby.OnClientConnected += HandleClientConected;
            NetworkManagerLobby.OnClientDisconnected += HandleOnClientDisconnected;
        }
        private void OnDisable() {
            NetworkManagerLobby.OnClientConnected -= HandleClientConected;
            NetworkManagerLobby.OnClientDisconnected -= HandleOnClientDisconnected;
        }

        // connect to IP
        public void JoinLobby() {
            string ipAddress = ipAddressInputField.text;

            networkManager.networkAddress = ipAddress;
            networkManager.StartClient();

            joinButton.interactable = false;
        }

        // update UI when player successfully connects or disconnects
        private void HandleClientConected() {
            joinButton.interactable = true;

            gameObject.SetActive(false);
            landingPagePanel.SetActive(false);
        }
        private void HandleOnClientDisconnected() {
            joinButton.interactable = true;
        }
    }
}
