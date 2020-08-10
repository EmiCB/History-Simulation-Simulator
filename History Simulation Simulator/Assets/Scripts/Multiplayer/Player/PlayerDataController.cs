using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDataController : MonoBehaviour {
    [SerializeField] private CharacterData characterData;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bioText;

    void Start() {
        nameText.text = characterData.name;
        titleText.text = characterData.title;
        bioText.text = characterData.biography;
    }
}
