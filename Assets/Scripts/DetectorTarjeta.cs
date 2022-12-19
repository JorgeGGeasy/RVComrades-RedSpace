using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public LinearMapping linearMapping;

        bool leerTarjeta = false;

        bool tarjetaLeida = false;
        // Start is called before the first frame update
        private void Start()
        {
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
                        Debug.Log("Tarjeta");
                        tarjeta.GetComponent<Rigidbody>().isKinematic = true;
                        tarjeta.transform.GetChild(0).gameObject.SetActive(false);
                        tarjetaLinearMap.transform.GetChild(0).gameObject.SetActive(true);
                        leerTarjeta = true;
                    }
                }
            }
            else
            {
                if(linearMapping.value > 0.9 && tarjetaLeida == false)
                {
                    Debug.Log("Hola");
                    // Se abre la puerta
                    tarjeta.transform.position = tarjetaLinearMap.transform.position;
                    tarjeta.GetComponent<Rigidbody>().isKinematic = false;
                    tarjeta.GetComponent<Rigidbody>().useGravity = true;
                    tarjeta.transform.GetChild(0).gameObject.SetActive(true);
                    tarjetaLinearMap.transform.GetChild(0).gameObject.SetActive(false);
                    tarjetaLeida = true;
                    StartCoroutine(IEPasarTarjetaLector());
                }
            }

            IEnumerator IEPasarTarjetaLector()
            {
                materialRojo.color = Color.HSVToRGB(0, 1, 0.2f);
                materialVerde.color = Color.HSVToRGB(0.35f, 1, 1f);

                puerta.GetComponent<Animator>().Play("Puerta");
                //audioClipManager.SeleccionarAudio(7, 0.5f);
                yield return new WaitForSeconds(1f);
                puerta.GetComponent<Animator>().enabled = false; // parar animacion
                subtitulos.IniciarSala();

            }
        }
    }
}
