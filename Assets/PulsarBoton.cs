using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    

    public class PulsarBoton : MonoBehaviour
    {
        [SerializeField]
        GameObject[] objetos;
        [SerializeField]
        Material materialActivado;
        [SerializeField]
        Material materialDesactivado;
        public int contador = 1;
        public void OnButtonDown(Hand fromHand)
        {
            switch (contador)
            {
                case 2:
                    contador = 0;
                    objetos[2].SetActive(true);
                    objetos[5].GetComponent<Renderer>().material = materialActivado;
                    objetos[1].SetActive(false);
                    objetos[4].GetComponent<Renderer>().material = materialDesactivado;
                    break;
                case 1:
                    contador++;
                    objetos[1].SetActive(true);
                    objetos[4].GetComponent<Renderer>().material = materialActivado;
                    objetos[0].SetActive(false);
                    objetos[3].GetComponent<Renderer>().material = materialDesactivado;
                    break;
                default:
                    contador++;
                    objetos[0].SetActive(true);
                    objetos[3].GetComponent<Renderer>().material = materialActivado;
                    objetos[2].SetActive(false);
                    objetos[5].GetComponent<Renderer>().material = materialDesactivado;
                    break;
            }
            Debug.Log("Pulsado");
        }
    }
}