using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



namespace Valve.VR.InteractionSystem
{
    [System.Serializable]
    public class DefaultRoom
    {
        public string Name;
        public int sceneIndex;
    }

    public class NetWorkManager : MonoBehaviourPunCallbacks
    {
        public List<DefaultRoom> defaultRooms;

        public void ConnectToServer()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Intentando conexion");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Conectado al server");
            base.OnConnectedToMaster();
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("We JoinedLobby");
            InitializeRoom(0);
        }

        public void InitializeRoom(int index)
        {
            DefaultRoom roomSettings = defaultRooms[index];

            PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            roomOptions.IsVisible = true;
            roomOptions.IsOpen = true;

            PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Entrando en una room");
            base.OnJoinedRoom();
        }

        public override void OnPlayerEnteredRoom(NPlayer newPlayer)
        {
            Debug.Log("Un jugador a entrado");
            base.OnPlayerEnteredRoom(newPlayer);
        }

    }
}