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

        bool puzle1 = false;
        bool puzle2 = false;
        bool puzle3 = false;
        bool puzle4 = false;

        // Update is called once per frame
        void Update()
        {
            if (patata.patataColocada)
            {
                puzle1 = true;
            }
            else
            {
                puzle1 = false;
            }
            
            if(linearMappingTarjeta.value > 0.9)
            {
                puzle2 = true;
            }
            else
            {
                puzle2 = false;
            }

            if(puzle1 && puzle2 && puzle3 && puzle4)
            {
                // Se permite el teletransporte al modulo lunar
            }
        }
    }

}
