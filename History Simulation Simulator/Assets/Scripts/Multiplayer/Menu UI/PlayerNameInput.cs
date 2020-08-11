using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmiCB.Lobby {
    public class PlayerNameInput : MonoBehaviour {
        [Header("UI")]
        [SerializeField] private TMP_InputField nameInputField = null;
        [SerializeField] private Button continueButton = null;

        // can get name, but only set internally
        public static string displayName {get; private set;}
        private const string playerPrefsNameKey = "PlayerName";

        private void Start() => SetUpInputField();

        private void SetUpInputField() {
            // don't do anything if player is new
            if (!PlayerPrefs.HasKey(playerPrefsNameKey)) return;

            // use previously used name
            string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);
            nameInputField.text = defaultName;
            SetPlayerName(defaultName);
        }

        // ensure name is valid, disable continuing if not
        public void SetPlayerName(string name) {
            name = nameInputField.text;
            continueButton.interactable = !string.IsNullOrEmpty(name);
        }

        // save player name after continuing
        public void SavePlayerName() {
            displayName = nameInputField.text;
            PlayerPrefs.SetString(playerPrefsNameKey, displayName);
        }
    }
}

