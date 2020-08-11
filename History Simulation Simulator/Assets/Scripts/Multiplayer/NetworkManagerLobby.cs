using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace EmiCB.Lobby {
    public class NetworkManagerLobby : NetworkManager {
        [SerializeField] private int minPlayers = 1;
        [SerializeField] private int defaultMaxPlayers = 30;

        [Scene] [SerializeField] private string menuScene = string.Empty;
        [Scene] [SerializeField] private string gameScene = string.Empty;

        [Header("Room")]
        [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

        [Header("Game")]
        [SerializeField] private NetworkGamePlayerLobby gamePlayerPrefab = null;
        [SerializeField] private GameObject playerSpawnSystem = null;

        // custom events
        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;
        public static event Action<NetworkConnection> OnServerRedied;

        // list of waiting players
        public List<NetworkRoomPlayerLobby> roomPlayers {get;} = new List<NetworkRoomPlayerLobby>();
        public List<NetworkGamePlayerLobby> gamePlayers {get;} = new List<NetworkGamePlayerLobby>();

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

        // when player joins, spawn them in and link with connection
        public override void OnServerAddPlayer(NetworkConnection conn) {
            if (SceneManager.GetActiveScene().path == menuScene) {
                // check if player is host
                bool isHost = roomPlayers.Count == 0;
                // spawn player in
                NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
                roomPlayerInstance.IsHost = isHost;
                NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
            }
        }

        // when player leaves
        public override void OnServerDisconnect(NetworkConnection conn) {
            // remove player from list
            if (conn.identity != null) {
                var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
                roomPlayers.Remove(player);
                NotifyPlayersOfReadyState();
            }

            base.OnClientDisconnect(conn);
        }

        // reset player list when server is stopped
        public override void OnStopServer() {
            roomPlayers.Clear();
        }

        // loop through all players and update ready statuses
        public void NotifyPlayersOfReadyState() {
            foreach (var player in roomPlayers) {
                player.HandleReadyToStart(IsReadyToStart());
            }
        }

        private bool IsReadyToStart() {
            if (numPlayers < minPlayers) return false;

            foreach (var player in roomPlayers) {
                if (!player.isReady) return false;
            }

            return true;
        }


        public void StartGame() {
            if (SceneManager.GetActiveScene().path == menuScene) {
                if (!IsReadyToStart()) return;

                ServerChangeScene("Simulation");
            }
        }

        // handle scene changes
        public override void ServerChangeScene(string newSceneName) {
            // menu to game
            if (SceneManager.GetActiveScene().path == menuScene && newSceneName.Equals(gameScene)) {
                for (int i = roomPlayers.Count - 1; i  >= 0; i--) {
                    var conn = roomPlayers[i].connectionToClient;
                    var gamePlayerInstance = Instantiate(gamePlayerPrefab);
                    gamePlayerInstance.SetDisplayName(roomPlayers[i].displayName);

                    NetworkServer.Destroy(conn.identity.gameObject);
                    NetworkServer.ReplacePlayerForConnection(conn, gamePlayerInstance.gameObject, true);
                }
            }

            base.ServerChangeScene(newSceneName);
        }
        public override void OnServerSceneChanged(string sceneName) {
            // check if main level
            if (sceneName.Equals(gameScene)) {
                GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
                NetworkServer.Spawn(playerSpawnSystem);
            }
        }

        public override void OnServerReady(NetworkConnection conn) {
            base.OnServerReady(conn);
            OnServerRedied?.Invoke(conn);
        }
    }
}

