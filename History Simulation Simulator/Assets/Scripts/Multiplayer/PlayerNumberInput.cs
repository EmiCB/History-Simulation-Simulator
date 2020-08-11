using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmiCB.Lobby {
    public class PlayerNumberInput : MonoBehaviour {
        [SerializeField] private NetworkManagerLobby networkManagerLobby = null;

        [Header("UI")]
        [SerializeField] private TMP_InputField playerNumberInputField = null;
        [SerializeField] private Button continueButton = null;

        // can get name, but only set internally
        public static int maxPlayers {get; private set;}
        private const string playerPrefsMaxPlayersKey = "MaxPlayers";

        private void Start() => SetUpInputField();

        private void SetUpInputField() {
            // don't do anything if player is new
            if (!PlayerPrefs.HasKey(playerPrefsMaxPlayersKey)) return;

            // use previously used max players
            int defaultMaxPlayers = PlayerPrefs.GetInt(playerPrefsMaxPlayersKey);
            playerNumberInputField.text = defaultMaxPlayers.ToString();
            SetPlayerMax(defaultMaxPlayers);
        }

        // ensure name is valid, disable continuing if not
        public void SetPlayerMax(int max) {
            int number;
            if (Int32.TryParse(playerNumberInputField.text, out number)) {
                max = number;
                continueButton.interactable = true;
                networkManagerLobby.maxConnections = max;
            }
            else {
                Debug.LogError("Invalid Number!");
                continueButton.interactable = false;
            }
        }

        // save player name after continuing
        public void SavePlayerName() {
            maxPlayers = Int32.Parse(playerNumberInputField.text);
            PlayerPrefs.SetInt(playerPrefsMaxPlayersKey, maxPlayers);
        }
    }
}

