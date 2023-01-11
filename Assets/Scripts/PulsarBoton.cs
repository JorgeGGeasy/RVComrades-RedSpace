using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
    

    public class PulsarBoton : MonoBehaviour
    {
        [SerializeField]
        GameObject[] objetos;
        [SerializeField]
        Material materialActivado;
        [SerializeField]
        Material materialDesactivado;
        public int contador = 1;


        private PhotonView photonView;
   
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }



        public void OnButtonDown(Hand fromHand)
        {
            switch (contador)
            {
                case 2:
                    photonView.RPC("caso2", RpcTarget.All);
                    break;
                case 1:
                    photonView.RPC("caso1", RpcTarget.All);
                    break;
                default:
                    photonView.RPC("caso0", RpcTarget.All);
                    break;
            }
            Debug.Log("Pulsado");
        }


        // activar cuadrado
        [PunRPC]
        private void caso0(){
            contador++;
            objetos[0].SetActive(true);
            objetos[3].GetComponent<Renderer>().material = materialActivado;
            objetos[2].SetActive(false);
            objetos[5].GetComponent<Renderer>().material = materialDesactivado;
        }


        // activar rombo
        [PunRPC]
        private void caso1(){
            contador++;
            objetos[1].SetActive(true);
            objetos[4].GetComponent<Renderer>().material = materialActivado;
            objetos[0].SetActive(false);
            objetos[3].GetComponent<Renderer>().material = materialDesactivado;
        }

        // activar circulo
        [PunRPC]
        private void caso2(){
            contador = 0;
            objetos[2].SetActive(true);
            objetos[5].GetComponent<Renderer>().material = materialActivado;
            objetos[1].SetActive(false);
            objetos[4].GetComponent<Renderer>().material = materialDesactivado;
        }

    }
}