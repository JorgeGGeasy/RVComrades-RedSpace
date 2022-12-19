using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class Martillo : MonoBehaviour
    {

        [SerializeField]
        private GameObject objetoARomperCaja;

        [SerializeField]
        private GameObject tapaMovible, tapaFija;

        [SerializeField]
        private int velocidadNecesariaParaRomper = 15;

        private bool roto = false;


        [SerializeField]
        private Animator romperCaja;

        
        // Update is called once per frame
        void Update()
        {
           
        }

        public void OnTriggerEnter(Collider objetoColision){
            Debug.Log("Colision --- ");

            if(objetoColision.gameObject == objetoARomperCaja && !roto){
                float velocidad = objetoColision.GetComponent<VelocityEstimator>().GetVelocityEstimate().magnitude;
                if(velocidad >= velocidadNecesariaParaRomper){
                    // romper
                    roto = true;
                    // poder que se pueda abrir la caja
                    tapaMovible.SetActive(true);
                    tapaFija.SetActive(false);
                    // animacion de romper cables
                    StartCoroutine(AnimacionRomperCaja());
                }
                
            }
        }

        IEnumerator AnimacionRomperCaja(){

            

            // romper cables --------------------------------
            romperCaja.Play("RomperCajaPatatas");
            yield return new WaitForSeconds(1.0f);
    
        }
    }
}