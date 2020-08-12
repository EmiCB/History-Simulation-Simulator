using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EmiCB.Lobby;

public class PlayerDataController : MonoBehaviour {
    public string displayName = null;
    public CharacterData characterData = null;

    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private TMP_Text titleText = null;
    [SerializeField] private TMP_Text bioText = null;

    void Start() {
        displayName = GetComponent<NetworkGamePlayerLobby>().displayName;
        characterData = GetComponent<NetworkGamePlayerLobby>().characterData;

        nameText.text = characterData.characterName;
        titleText.text = characterData.title;
        bioText.text = characterData.biography;
    }
}
