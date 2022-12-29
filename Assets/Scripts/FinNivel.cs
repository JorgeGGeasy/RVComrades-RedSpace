using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



namespace Valve.VR.InteractionSystem
{
    public class FinNivel : MonoBehaviour
    {
        [SerializeField]
        GameObject teleport;

        [SerializeField]
        ColocarPatata patata;

        [SerializeField]
        LinearMapping linearMappingTarjeta;

        [SerializeField]
        PrepararObjetos prepararObjetos;

        [SerializeField]
        private AudioClipManager audioClipManager;

        [SerializeField]
        Trayectoria trayectoria;

        bool puzle1 = false;
        bool puzle2 = false;
        bool puzle3 = false;
        bool puzle4 = false;

        bool nivelCompletado = false;

        [SerializeField]
        private GameObject[] luces;

        [SerializeField]
        private Color colorRojoLuz;

        [SerializeField]
        private Color colorVerdeLuz;

        private PhotonView photonView;
    // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!nivelCompletado)
            {
                if (patata.patataColocada && !puzle1)
                {
                    photonView.RPC("puzlePatataColocada", RpcTarget.All);
                }

                if (linearMappingTarjeta.value > 0.9 && !puzle2)
                {

                    photonView.RPC("puzlePuertaBanyoTRUE", RpcTarget.All);
                   


                }
                else if(linearMappingTarjeta.value < 0.9 && puzle2)
                {
                    photonView.RPC("puzlePuertaBanyoFALSE", RpcTarget.All);
                    

                }

                if (prepararObjetos.objetos && !puzle3)
                {
                    photonView.RPC("puzlePrepararObjetos", RpcTarget.All);
                }

                if (trayectoria.completo && !puzle4)
                {

                    photonView.RPC("puzleTrayectoriaCompleto", RpcTarget.All);
                    
                }

                if (puzle1 && puzle2 && puzle3 && puzle4)
                {
                    // Se permite el teletransporte al modulo lunar
                    photonView.RPC("PuzleCompletado", RpcTarget.All);
                    
                }
            }
            else
            {
                teleport.SetActive(true);
            }



        }

        [PunRPC]
        private void PuzleCompletado(){
            Debug.Log("PuzleCompletado");
            nivelCompletado = true;
        }

        [PunRPC]
        private void puzlePatataColocada(){
            puzle1 = true;
            cambiarLuz(0, puzle1);
        }

        [PunRPC]
        private void puzlePrepararObjetos(){
            puzle3 = true;
            cambiarLuz(2, puzle3);
        }


        [PunRPC]
        private void puzleTrayectoriaCompleto(){
            puzle4 = true;
            cambiarLuz(3, puzle4);
        }

        [PunRPC]
        private void puzlePuertaBanyoTRUE(){
            puzle2 = true;
            cambiarLuz(1, puzle2);
            if (!audioClipManager.GetComponent<AudioSource>().isPlaying)
            {
                audioClipManager.SeleccionarAudio(6, 2f);
            }
        }

        [PunRPC]
        private void puzlePuertaBanyoFALSE(){
            puzle2 = false;
            cambiarLuz(1, puzle2); 
        }
        

         

        void cambiarLuz(int numero, bool activo)
        {
            luces[numero].GetComponent<Light>().color = activo ? colorVerdeLuz : colorRojoLuz;
        }
    }

}
