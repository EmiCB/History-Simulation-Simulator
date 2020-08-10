using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationDataController : MonoBehaviour {
    [SerializeField] private SimulationData simulationData = new SimulationData();

    public void UpdateLevelData(LevelData newLevelData) {
        simulationData.levelData = newLevelData;
    }

    public void SaveSimulationData() {
        
    }
}
