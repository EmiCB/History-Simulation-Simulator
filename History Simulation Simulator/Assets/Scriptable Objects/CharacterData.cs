using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject {
    public string name;
    public string title;
    [TextArea] public string biography;
}
