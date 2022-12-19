using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem.Sample
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
        [SerializeField]
        FinNivel final;

        bool primerPuzle = false;
        bool segundoPuzle = false;
        bool tercerPuzle = false;
        bool completo = false;

        [SerializeField]
        GameObject[] objetos;
        public void Update()
        {
            //CuboPequeñoIzquierda
            if (forma.contador == 1 && posicion.value > 0.9 && escala.value < 0.2 && !primerPuzle)
            {
                Debug.Log("CuboPequeño");
                primerPuzle = true;
                objetos[0].SetActive(false);
            }
            //CirculoMedianoEnmedio
            if (forma.contador == 2 && posicion.value > 0.45 && posicion.value < 0.55 && escala.value > 0.2 && escala.value < 0.8 && !segundoPuzle)
            {
                Debug.Log("RomboMediano");
                segundoPuzle = true;
                objetos[1].SetActive(false);
            }
            //RomboGrandeDerecha
            if (forma.contador == 0 && posicion.value < 0.08 && escala.value > 0.7 && !tercerPuzle)
            {
                Debug.Log("CirculoGrande");
                tercerPuzle = true;
                objetos[2].SetActive(false);
            }

            if(primerPuzle && segundoPuzle && tercerPuzle && !completo)
            {
                final.puzle4 = true;
                completo = true;
            }
            
            
        }
    }
}
