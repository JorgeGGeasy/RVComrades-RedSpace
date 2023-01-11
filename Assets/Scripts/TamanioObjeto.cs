using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
    public class TamanioObjeto : MonoBehaviour
    {
        [SerializeField]
        LinearMapping linearMapping;

        private PhotonView photonView;
    // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("VALUE: -- "+linearMapping.value);
            if (linearMapping.value < 0.4)
            {
                photonView.RPC("tamanyo1", RpcTarget.All);
            }
            else if (linearMapping.value > 0.4 && linearMapping.value < 0.8)
            {
                photonView.RPC("tamanyo2", RpcTarget.All);
            }
            else if (linearMapping.value > 0.8)
            {
                photonView.RPC("tamanyo3", RpcTarget.All);
            }
        }


        [PunRPC]
        private void tamanyo1(){
            Debug.Log("t1");
            gameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        }

        [PunRPC]
        private void tamanyo2(){
            Debug.Log("t2");
           gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        [PunRPC]
        private void tamanyo3(){
            Debug.Log("t3");
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}
