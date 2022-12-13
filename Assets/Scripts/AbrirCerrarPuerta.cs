using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class AbrirCerrarPuerta : MonoBehaviour
    {
        [SerializeField]
        Transform cerrada;
        [SerializeField]
        Transform abierta;
        
        public LinearMapping linearMapping;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(linearMapping.value > 0.9)
            {
                
            }
            else if(linearMapping.value < 0.1)
            {

            }

        }
    }
}
