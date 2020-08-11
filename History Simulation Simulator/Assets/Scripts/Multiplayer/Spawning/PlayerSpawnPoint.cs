using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmiCB.Lobby {
    public class PlayerSpawnPoint : MonoBehaviour {
        private void Awake() => PlayerSpawnSystem.AddSpawnPoint(transform);
        private void OnDestroy() => PlayerSpawnSystem.RemoveSpawnPoint(transform);

        // visualize in editor
        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position, 1.0f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2.0f);
        }
    }
}