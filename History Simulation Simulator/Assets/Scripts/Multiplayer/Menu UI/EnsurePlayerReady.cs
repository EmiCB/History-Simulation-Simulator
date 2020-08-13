using UnityEngine;
using UnityEngine.UI;
using EmiCB.Lobby;
using Mirror;

public class EnsurePlayerReady : NetworkBehaviour {
    [SerializeField] private Button readyButton = null;

    public override void OnStartAuthority() {
        enabled = true;
    }

    private void OnGUI() {
        if (gameObject.GetComponent<NetworkRoomPlayerLobby>().characterData != null) readyButton.interactable = true;
    }
}
