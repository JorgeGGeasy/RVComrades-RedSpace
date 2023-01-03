using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class PrepararObjetos : MonoBehaviour
    {

        [SerializeField]
        GameObject[] objetosNecesarios;

        FinNivel finNivelScript;

        int contador;

        public bool objetos;
        // Start is called before the first frame update
        void Start()
        {
            finNivelScript = FinNivel.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider c)
        {
            Debug.Log(objetosNecesarios.Length);
            foreach(GameObject objetoNecesario in objetosNecesarios)
            {
                if (c.gameObject == objetoNecesario && !objetos)
                {
                    Debug.Log("Colision");
                    objetoNecesario.transform.position = new Vector3(999.0f,999.0f,999.0f);
                    contador++;                
                }
            }

            if (contador == objetosNecesarios.Length)
            {
                finNivelScript.FinalizadoPuzlePrepararObjetos();
                //objetos = true;
            }

        }
    }
}