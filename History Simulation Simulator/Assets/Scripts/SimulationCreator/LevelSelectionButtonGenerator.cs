using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectionButtonGenerator : MonoBehaviour {
    [SerializeField] private LevelData[] levels;
    [SerializeField] private RectTransform contentParent;
    [SerializeField] private GameObject buttonPrefab;

    private void Start() {
        // add all levels to list
        levels = Resources.LoadAll<LevelData>("LevelData");
        // create buttons
        for (int i = 0; i < levels.Length; i++) {
            GameObject newButton = Instantiate(buttonPrefab);
            newButton.transform.SetParent(contentParent);
            newButton.transform.localScale = Vector3.one;
            newButton.GetComponent<LevelSelectionButton>().levelData = levels[i];
            newButton.GetComponentInChildren<TMP_Text>().text = levels[i].levelName;
        }
    }
}
