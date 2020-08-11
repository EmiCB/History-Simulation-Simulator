using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;

namespace EmiCB.Lobby {
    public class PlayerSpawnSystem : NetworkBehaviour {
        [SerializeField] private GameObject playerPrefab = null;

        private static List<Transform> spawnPoints = new List<Transform>();
        private int nextIndex;

        // add and remove spawn points
        public static void AddSpawnPoint(Transform transform) {
            spawnPoints.Add(transform);
            spawnPoints = spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
        }
        public static void RemoveSpawnPoint(Transform transform) => spawnPoints.Remove(transform);

        // subscribe & unsubscribe server redied event
        public override void OnStartServer() => NetworkManagerLobby.OnServerRedied += SpawnPlayer;
        [ServerCallback]
        private void OnDestroy() => NetworkManagerLobby.OnServerRedied -= SpawnPlayer;


        [Server]
        public void SpawnPlayer(NetworkConnection conn) {
            // get next spawn point in list
            Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);
            // make sure it exists
            if (spawnPoint == null) {
                Debug.LogError($"Missing spawn point for player {nextIndex}");
                return;
            }

            GameObject playerInstance = Instantiate(playerPrefab, spawnPoints[nextIndex].position, spawnPoints[nextIndex].rotation);
            NetworkServer.AddPlayerForConnection(conn, playerInstance);
            //nextIndex++;
            nextIndex = (nextIndex + 1) % spawnPoints.Count;
        }
    }
}

