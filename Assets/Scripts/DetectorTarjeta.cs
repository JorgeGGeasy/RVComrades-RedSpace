using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
    public class DetectorTarjeta : MonoBehaviour
    {
        [SerializeField]
        float radio;
        [SerializeField]
        GameObject tarjeta;
        [SerializeField]
        GameObject tarjetaLinearMap;
        [SerializeField]
        Material materialRojo;
        [SerializeField]
        Material materialVerde;
        [SerializeField]
        GameObject puerta;

        [SerializeField]
        Subtitulos subtitulos;

        [SerializeField]
        private AudioClipManager audioClipManager;

        public LinearMapping linearMapping;

        bool leerTarjeta = false;

        bool tarjetaLeida = false;


        private PhotonView photonView;

        // Start is called before the first frame update
        private void Start()
        {
            photonView = GetComponent<PhotonView>();
            materialRojo.color = Color.HSVToRGB(0, 1, 1);
            materialVerde.color = Color.HSVToRGB(0.35f, 1, 0.2f);
        }

        void Update()
        {
            if (!leerTarjeta)
            {
                Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radio);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.transform.parent.gameObject == tarjeta)
                    {
                        photonView.RPC("colocarTarjeta", RpcTarget.All);
                    }
                }
            }
            else
            {
                if(linearMapping.value > 0.9 && tarjetaLeida == false)
                {
                    Debug.Log("Hola");
                    // Se abre la puerta
                    photonView.RPC("moverTarjeta", RpcTarget.All);
                    StartCoroutine(IEPasarTarjetaLector());
                    
                }
            }

            IEnumerator IEPasarTarjetaLector()
            {
                photonView.RPC("animarPuerta", RpcTarget.All);
                yield return new WaitForSeconds(1f);
                photonView.RPC("pararPuerta", RpcTarget.All);

            }
        }

    
    [PunRPC]
    private void colocarTarjeta(){
        Debug.Log("Tarjeta");
        tarjeta.GetComponent<Rigidbody>().isKinematic = true;
        tarjeta.transform.GetChild(0).gameObject.SetActive(false);
        tarjetaLinearMap.transform.GetChild(0).gameObject.SetActive(true);
        leerTarjeta = true;
    }

    [PunRPC]
    private void moverTarjeta(){
        tarjeta.transform.position = tarjetaLinearMap.transform.position;
        tarjeta.GetComponent<Rigidbody>().isKinematic = false;
        tarjeta.GetComponent<Rigidbody>().useGravity = true;
        tarjeta.transform.GetChild(0).gameObject.SetActive(true);
        tarjetaLinearMap.transform.GetChild(0).gameObject.SetActive(false);
        tarjetaLeida = true;
    }


    // funciones PUNRPC animaciones
    [PunRPC]
    private void animarPuerta(){
        audioClipManager.SeleccionarAudio(1, 0.5f);
        materialRojo.color = Color.HSVToRGB(0, 1, 0.2f);
        materialVerde.color = Color.HSVToRGB(0.35f, 1, 1f);

        puerta.GetComponent<Animator>().Play("Puerta");
        audioClipManager.SeleccionarAudio(2, 0.5f);
    }

    [PunRPC]
    private void pararPuerta(){
        puerta.GetComponent<Animator>().enabled = false; // parar animacion
        subtitulos.IniciarSala();
    }


    }
}
