using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmiCB.Lobby.CharacterSelection {
    public class CharacterButtonGenerator : MonoBehaviour {
        [SerializeField] private RectTransform contentParent = null;
        [SerializeField] private GameObject characterButtonPrefab = null;
        [SerializeField] private CharacterData[] characterDatas = null;
        public Button[] characterButtons = null;

        private void Awake() {
            characterButtons = new Button[characterDatas.Length];
            // create buttons
            for (int i = 0; i < characterDatas.Length; i++) {
                GameObject newButton = Instantiate(characterButtonPrefab);
                newButton.transform.SetParent(contentParent, false);
                newButton.GetComponent<CharacterButton>().characterData = characterDatas[i];
                newButton.GetComponentInChildren<TMP_Text>().text = characterDatas[i].characterName;
                characterButtons[i] = newButton.GetComponent<Button>();
                newButton.GetComponent<CharacterButton>().characterButtonGenerator = this;
            }
        }
    }
}

