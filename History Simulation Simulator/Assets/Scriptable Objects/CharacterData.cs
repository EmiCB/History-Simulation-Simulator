using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject {
    public string characterName;
    public string title;
    [TextArea(5, 15)] public string biography;
}
