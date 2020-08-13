﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EmiCB.Lobby.CharacterSelection {
    public class CharacterButton : MonoBehaviour {
        public CharacterData characterData;

        public void ChooseCharacter() {
            gameObject.GetComponentInParent<NetworkRoomPlayerLobby>().CmdSetCharacterData(characterData);
        }
    }
}
