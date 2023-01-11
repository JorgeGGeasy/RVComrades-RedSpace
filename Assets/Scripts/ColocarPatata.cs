using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace Valve.VR.InteractionSystem
{
    public class ColocarPatata : MonoBehaviour
    {
        [SerializeField]
        float radio;

        [SerializeField]
        GameObject patataCaja;

        [SerializeField]
        private Color colorLuz;

        [SerializeField]
        private AudioClipManager audioClipManager;

        [SerializeField]
        private AudioSource audioClipManagerFondo;

        public bool patataColocada = false;
        private Collider hitColliderTemp;
        
        private PhotonView photonView;

        private FinNivel finNivel;
    
        void Start()
        {
            finNivel = FinNivel.Instance;
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!patataColocada)
            {
                Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radio);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.tag == "Patata")
                    {
                        hitColliderTemp = hitCollider;
                        photonView.RPC("colocarPatata", RpcTarget.All);
                        
                    }
                }
            }
        }


        [PunRPC]
        private void colocarPatata(){
            Debug.Log("Patata");
            patataCaja.gameObject.SetActive(true);
            hitColliderTemp.gameObject.transform.position = new Vector3(999.0f, 999.0f, 999.0f);
            finNivel.FinalizadoPuzlePatataColocada();
            patataColocada = true;
            StartCoroutine(AnimacionEncenderLuces());
        }

        IEnumerator AnimacionEncenderLuces(){

            // ------------------
            GameObject[] luces =  GameObject.FindGameObjectsWithTag("Luces");
            GameObject[] linternas =  GameObject.FindGameObjectsWithTag("Linterna");
            bool boolParpadear = false;

            // TODO sonido de apagar generador
            // Audio encendiendose motores
            audioClipManager.SeleccionarAudio(4, 0.1f);
            encenderLuces(luces,linternas);
            
            //parpadear Luces
            for(int i = 0; i<6; i++){
                parpadearLuces(luces,boolParpadear);
                boolParpadear = !boolParpadear;
                audioClipManager.SeleccionarAudio(3, 0.5f);
                yield return new WaitForSeconds(0.1f);
            }


            yield return new WaitForSeconds(4f);
            audioClipManagerFondo.UnPause();

        }

        private void parpadearLuces(GameObject[] luces, bool encender){
            

            foreach(GameObject luz in luces){
                luz.GetComponent<Light>().intensity = encender ? 1.6f : 0.6f;
            }
        }

        private void encenderLuces(GameObject[] luces,GameObject[] linternas){
        
            foreach(GameObject luz in luces){
                luz.GetComponent<Light>().intensity = 2.6f;
                luz.GetComponent<Light>().color = colorLuz;
            }

            foreach(GameObject linterna in linternas){
                linterna.GetComponent<Light>().intensity = 0.0f;
            }
        }
    }
}