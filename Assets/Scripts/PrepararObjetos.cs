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
            int cont = 0;
            foreach (GameObject objetoNecesario in objetosNecesarios)
            {
                if (c.gameObject == objetoNecesario && !objetos)
                {
                    Debug.Log("Es");
                    photonView.RPC("ponerObjetos", RpcTarget.All, cont);
                }
                cont++;
            }
            if (contador == objetosNecesarios.Length)
            {
                finNivelScript.FinalizadoPuzlePrepararObjetos();
                //objetos = true;
            }

        }

        [PunRPC]
        private void ponerObjetos(int objetoNecesario)
        {
            Debug.Log("Entra");
            objetosNecesarios[objetoNecesario].transform.position = new Vector3(999.0f, 999.0f, 999.0f);
            contador++;

        }
    }
}