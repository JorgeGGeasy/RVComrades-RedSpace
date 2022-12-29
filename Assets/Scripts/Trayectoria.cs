using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace Valve.VR.InteractionSystem
{
    public class Trayectoria : MonoBehaviour
    {

        // El valor 1 es la izquierda del todo
        [SerializeField]
        LinearMapping posicion;
        [SerializeField]
        LinearMapping escala;
        [SerializeField]
        PulsarBoton forma;

        bool primerPuzle = false;
        bool segundoPuzle = false;
        bool tercerPuzle = false;
        public bool completo = false;

        [SerializeField]
        GameObject[] objetos;


        private PhotonView photonView;
   
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }



        public void Update()
        {
            //CuboPeque�oIzquierda
            if (forma.contador == 1 && posicion.value > 0.9 && escala.value < 0.4 && !primerPuzle)
            {
                photonView.RPC("casoCuadrado", RpcTarget.All);
            }
            //Rombo
            if (forma.contador == 2 && posicion.value > 0.45 && posicion.value < 0.55 && escala.value > 0.4 && escala.value < 0.8 && !segundoPuzle)
            {
                photonView.RPC("casoRombo", RpcTarget.All);
            }
            //Circulo
            if (forma.contador == 0 && posicion.value < 0.08 && escala.value > 0.7 && !tercerPuzle)
            {
                photonView.RPC("casoCirculo", RpcTarget.All);
            }

            if(primerPuzle && segundoPuzle && tercerPuzle && !completo)
            {
                photonView.RPC("casoCompleto", RpcTarget.All);
            }
            
            
        }



        // activar cuadrado
        [PunRPC]
        private void casoCuadrado(){
            Debug.Log("CuboPequenio");
            primerPuzle = true;
            objetos[0].SetActive(false);
        }


        // activar rombo
        [PunRPC]
        private void casoRombo(){
            Debug.Log("RomboMediano");
            segundoPuzle = true;
            objetos[1].SetActive(false);
        }

        // activar circulo
        [PunRPC]
        private void casoCirculo(){
            Debug.Log("CirculoGrande");
            tercerPuzle = true;
            objetos[2].SetActive(false);
        }

        [PunRPC]
        private void casoCompleto(){
            completo = true;
        }


    }
}
