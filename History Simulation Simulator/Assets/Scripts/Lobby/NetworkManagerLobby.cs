using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace EmiCB.Lobby {
    public class NetworkManagerLobby : NetworkManager {
        [Scene] [SerializeField] private string menuScene = string.Empty;

        [Header("Room")]
        [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;

        // load gameobjects from Resources/SpawnablePrefabs folder (Server)
        public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

        // load gameobjects from Resources/SpawnablePrefabs folder (Client)
        public override void OnStartClient() {
            var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");
            foreach (var prefab in spawnablePrefabs) {
                ClientScene.RegisterPrefab(prefab);
            }
        }

        // call custom events
        public override void OnClientConnect(NetworkConnection conn) {
            base.OnClientConnect(conn);
            OnClientConnected?.Invoke();
        }
        public override void OnClientDisconnect(NetworkConnection conn) {
            base.OnClientDisconnect(conn);
            OnClientDisconnected?.Invoke();
        }

        // server logic for when client connects
        public override void OnServerConnect(NetworkConnection conn) {
            // check if hitting player limit
            if (numPlayers >= maxConnections) {
                conn.Disconnect();
                return;
            }

            // stops people from joining while game is in progress
            /*
            if (SceneManager.GetActiveScene().name != menuScene) {
                conn.Disconnect();
                return;
            }
            /* */
        }

        public override void OnServerAddPlayer(NetworkConnection conn) {
            if (SceneManager.GetActiveScene().name == menuScene) {
                NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
                NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
            }
        }
    }
}

