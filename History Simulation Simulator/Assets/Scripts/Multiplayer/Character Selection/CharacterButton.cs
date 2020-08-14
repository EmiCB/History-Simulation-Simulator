using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EmiCB.Lobby.CharacterSelection {
    public class CharacterButton : MonoBehaviour {
        public CharacterData characterData = null;
        public CharacterButtonGenerator characterButtonGenerator;

        public void ChooseCharacter() {
            gameObject.GetComponentInParent<NetworkRoomPlayerLobby>().CmdSetCharacterData(characterData);

            for (int i = 0; i < characterButtonGenerator.characterButtons.Length; i++) {
                characterButtonGenerator.characterButtons[i].interactable = true;
            }
        }
    }
}
