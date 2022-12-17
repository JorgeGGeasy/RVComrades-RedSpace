using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem
{
    public class FinNivel : MonoBehaviour
    {
        [SerializeField]
        ColocarPatata patata;

        [SerializeField]
        LinearMapping linearMappingTarjeta;

        [SerializeField]
        PrepararObjetos prepararObjetos;

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
                if (patata.patataColocada)
                {
                    puzle1 = true;
                    cambiarLuz(0, puzle1);
                }

                if (linearMappingTarjeta.value > 0.9)
                {
                    puzle2 = true;
                    cambiarLuz(1, puzle2);
                }
                else
                {
                    puzle2 = false;
                    cambiarLuz(1, puzle2);
                }

                if (prepararObjetos.objetos)
                {
                    puzle3 = true;
                    cambiarLuz(2, puzle3);
                }

                if (puzle1 && puzle2 && puzle3 && puzle4)
                {
                    // Se permite el teletransporte al modulo lunar
                    Debug.Log("PuzleCompletado");
                }
            }
            else
            {
                // Activa el tp point a la escena del modulo lunar
            }



        }

        void cambiarLuz(int numero, bool activo)
        {
            luces[numero].GetComponent<Light>().color = activo ? colorVerdeLuz : colorRojoLuz;
        }
    }

}
