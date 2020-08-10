using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmiCB.Lobby {
    public class MainMenu : MonoBehaviour {
        [SerializeField] private NetworkManagerLobby networkManager = null;

        [Header("UI")]
        [SerializeField] private GameObject mainButtons = null;
        [SerializeField] private GameObject hostingPanel = null;

        public void HostLobby() {
            networkManager.StartHost();
            mainButtons.SetActive(false);
            hostingPanel.SetActive(false);
        }
    }
}

