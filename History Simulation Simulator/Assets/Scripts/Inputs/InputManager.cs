using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmiCB.Inputs;

public class InputManager : MonoBehaviour {
    private static readonly IDictionary<string, int> mapStates = new Dictionary<string, int>();
    
    private static Controls controls;
    public static Controls Controls {
        get {
            if (controls != null) return controls;
            return controls = new Controls();
        }
    }

    private void Awake() {
        if (controls != null) return;
        controls = new Controls();
    }

    private void OnEnable() => Controls.Enable();
    private void OnDisable() => Controls.Disable();
    private void OnDestroy() => controls = null;

    // stop player input
    public static void Add(string mapName) {
        mapStates.TryGetValue(mapName, out int value);
        mapStates[mapName] = value + 1;

        UpdateMapState(mapName);
    }

    // allow player input
    public static void Remove(string mapName) {
        mapStates.TryGetValue(mapName, out int value);
        mapStates[mapName] = Mathf.Max(value - 1, 0);

        UpdateMapState(mapName);
    }

    // update input status
    private static void UpdateMapState(string mapName) {
        int value = mapStates[mapName];

        if (value > 0) {
            Controls.asset.FindActionMap(mapName).Disable();
            return;
        }

        Controls.asset.FindActionMap(mapName).Enable();
    }
}
