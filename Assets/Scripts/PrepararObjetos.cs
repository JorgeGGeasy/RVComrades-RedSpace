using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
    public class PrepararObjetos : MonoBehaviour
    {

        [SerializeField]
        GameObject[] objetosNecesarios;

        FinNivel finNivelScript;

        int contador;

        public bool objetos;


        private PhotonView photonView;

        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
            finNivelScript = FinNivel.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider c)
        {
            Debug.Log(objetosNecesarios.Length);
            foreach (GameObject objetoNecesario in objetosNecesarios)
            {
                if (c.gameObject == objetoNecesario && !objetos)
                {
                    photonView.RPC("PlayApagarLuces", RpcTarget.All, objetoNecesario);
                }
            }
            if (contador == objetosNecesarios.Length)
            {
                finNivelScript.FinalizadoPuzlePrepararObjetos();
                //objetos = true;
            }

        }

        [PunRPC]
        private void ponerObjetos(GameObject objetoNecesario)
        {

            objetoNecesario.transform.position = new Vector3(999.0f, 999.0f, 999.0f);
            contador++;
            
        }
    }
}