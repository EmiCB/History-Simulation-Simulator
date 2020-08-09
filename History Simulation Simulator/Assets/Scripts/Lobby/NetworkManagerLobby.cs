﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace EmiCB.Lobby {
    public class NetworkManagerLobby : NetworkManager {
        [SerializeField] private int minPlayers = 1;

        [Scene] [SerializeField] private string menuScene = string.Empty;

        [Header("Room")]
        [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

        // custom events
        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;

        // list of waiting players
        public List<NetworkRoomPlayerLobby> roomPlayers {get;} = new List<NetworkRoomPlayerLobby>();

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
                //NotifyPlayersOfReadyState();
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
    }
}

