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

        public bool puzle1 = false; // puzle Patata
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


        public static FinNivel Instance; // A static reference to the GameManager instance

        void Awake()
        {
            if(Instance == null) // If there is no instance already
            {
                DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
                Instance = this;
            } else if(Instance != this) // If there is already an instance and it's not `this` instance
            {
                Destroy(gameObject); // Destroy the GameObject, this component is attached to
            }
        }

        void Start(){
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!nivelCompletado)
            {
                

                /*if (linearMappingTarjeta.value > 0.9 && !puzle2)
                {

                    photonView.RPC("puzlePuertaBanyoTRUE", RpcTarget.All);
                   


                }
                else if(linearMappingTarjeta.value < 0.9 && puzle2)
                {
                    photonView.RPC("puzlePuertaBanyoFALSE", RpcTarget.All);
                    

                }*/

                
                

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


        public void FinalizadoPuzlePatataColocada(){
            photonView.RPC("puzlePatataColocada", RpcTarget.All);
        }
        public void FinalizadoPuzlePuertaBanyo(bool valid){
            photonView.RPC("puzlePuertaBanyo", RpcTarget.All, valid);
        }
        
        public void FinalizadoPuzleTrayectoria(){
            photonView.RPC("puzleTrayectoriaCompleto", RpcTarget.All);
        }
        public void FinalizadoPuzlePrepararObjetos(){
            photonView.RPC("puzlePrepararObjetos", RpcTarget.All);
        }

        [PunRPC]
        private void PuzleCompletado(){
            Debug.Log("PuzleCompletado");
            nivelCompletado = true;
        }

        [PunRPC]
        private void puzlePatataColocada(){
            Debug.Log("Puzle Patata");
            puzle1 = true;
            cambiarLuz(0, puzle1);
        }

        [PunRPC]
        private void puzlePrepararObjetos(){
            Debug.Log("Puzle Preparar");
            puzle3 = true;
            cambiarLuz(2, puzle3);
        }


        [PunRPC]
        private void puzleTrayectoriaCompleto(){
            Debug.Log("Puzle trayectoria");
            puzle4 = true;
            cambiarLuz(3, puzle4);
        }

        [PunRPC]
        private void puzlePuertaBanyo(bool valid){
            Debug.Log("Puzle puerta true");
            puzle2 = valid;
            cambiarLuz(1, valid);
            if (!audioClipManager.GetComponent<AudioSource>().isPlaying)
            {
                audioClipManager.SeleccionarAudio(6, 2f);
            }
        }

        

         

        void cambiarLuz(int numero, bool activo)
        {
            luces[numero].GetComponent<Light>().color = activo ? colorVerdeLuz : colorRojoLuz;
        }
    }

}
