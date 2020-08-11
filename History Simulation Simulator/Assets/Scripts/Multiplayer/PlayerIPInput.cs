using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmiCB.Lobby {
    public class PlayerIPInput : MonoBehaviour {
        [Header("UI")]
        [SerializeField] private TMP_InputField ipInputField = null;
        [SerializeField] private Button continueButton = null;

        // can get name, but only set internally
        public static string ipAddress {get; private set;}
        private const string playerPrefsIPKey = "LastUsedIP";

        private void Start() => SetUpInputField();

        private void SetUpInputField() {
            // don't do anything if player is new
            if (!PlayerPrefs.HasKey(playerPrefsIPKey)) return;

            // use previously used name
            string defaultIP = PlayerPrefs.GetString(playerPrefsIPKey);
            ipInputField.text = defaultIP;
            SetPlayerIP(defaultIP);
        }

        // ensure name is valid, disable continuing if not
        public void SetPlayerIP(string ip) {
            ip = ipInputField.text;
            continueButton.interactable = !string.IsNullOrEmpty(ip);
        }

        // save player name after continuing
        public void SavePlayerIP() {
            ipAddress = ipInputField.text;
            PlayerPrefs.SetString(playerPrefsIPKey, ipAddress);
        }
    }
}

