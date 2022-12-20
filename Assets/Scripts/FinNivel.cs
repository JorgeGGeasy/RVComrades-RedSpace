using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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

        // Update is called once per frame
        void Update()
        {
            if (!nivelCompletado)
            {
                if (patata.patataColocada && !puzle1)
                {
                    puzle1 = true;
                    cambiarLuz(0, puzle1);
                }

                if (linearMappingTarjeta.value > 0.9 && !puzle2)
                {
                    puzle2 = true;
                    cambiarLuz(1, puzle2);
                    if (!audioClipManager.GetComponent<AudioSource>().isPlaying)
                    {
                        audioClipManager.SeleccionarAudio(6, 2f);
                    }


                }
                else if(linearMappingTarjeta.value < 0.9 && puzle2)
                {
                    puzle2 = false;
                    cambiarLuz(1, puzle2); 

                }

                if (prepararObjetos.objetos && !puzle3)
                {
                    puzle3 = true;
                    cambiarLuz(2, puzle3);
                }

                if (trayectoria.completo && !puzle4)
                {
                    puzle4 = true;
                    cambiarLuz(3, puzle4);
                }

                if (puzle1 && puzle2 && puzle3 && puzle4)
                {
                    // Se permite el teletransporte al modulo lunar
                    Debug.Log("PuzleCompletado");
                    nivelCompletado = true;
                }
            }
            else
            {
                teleport.SetActive(true);
            }



        }

        void cambiarLuz(int numero, bool activo)
        {
            luces[numero].GetComponent<Light>().color = activo ? colorVerdeLuz : colorRojoLuz;
        }
    }

}
