using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionButton : MonoBehaviour {
    [SerializeField] private SimulationDataController simulationDataController;
    public LevelData levelData;

    private void Start() {
        // ensure sim data controller is set
        simulationDataController = GameObject.FindObjectOfType<SimulationDataController>();
    }

    public void SelectLevel() {
        simulationDataController.UpdateLevelData(levelData);
    }
}
