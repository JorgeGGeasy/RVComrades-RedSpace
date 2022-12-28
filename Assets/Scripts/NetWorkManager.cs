using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public TeleportPoint teleportPoint;
        private string cambioEscena;
        private string anteriorEscena;
        public bool unaVez;

        // Start is called before the first frame update
        void Start()
        {
            ConnectToServer();
            anteriorEscena = teleportPoint.CambioEscena;
            cambioEscena = teleportPoint.CambioEscena;
        }

        private void Update()
        {
            cambioEscena = teleportPoint.CambioEscena;
            if(cambioEscena != anteriorEscena)
            {
                if(cambioEscena == "Nave")
                {
                    Debug.Log("Hola");
                    InitializeRoom(1);
                    anteriorEscena = cambioEscena;
                }
            }
        }

        private void ConnectToServer()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Intentando conexion");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Conectado al server");
            base.OnConnectedToMaster();
            if (unaVez)
            {
                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 2;
                roomOptions.IsVisible = true;
                roomOptions.IsOpen = true;
                PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
            }

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