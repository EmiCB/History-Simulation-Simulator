using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject {
    public string levelName = null;
    public Image image = null;
    public GameObject level = null;
}
