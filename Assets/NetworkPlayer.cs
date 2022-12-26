using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class NetworkPlayer : MonoBehaviour
{
    public Player player;
    public Valve.VR.InteractionSystem.Hand manoIzquierda;
    public Valve.VR.InteractionSystem.Hand manoDerecha;
    public Camera camara;

    public Transform cabeza;
    public Transform manoIzq;
    public Transform manoDch;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            manoDch.gameObject.SetActive(false);
            manoIzq.gameObject.SetActive(false);
            cabeza.gameObject.SetActive(false);

            manoIzq.transform.position = manoIzquierda.transform.position;
            manoDch.transform.position = manoDerecha.transform.position;
            /*MapPosition(cabeza, XRNode.Head);
            MapPosition(manoIzq, XRNode.LeftHand);
            MapPosition(manoDch, XRNode.RightHand);*/
        }
    }

    void MapPosition(Transform target, XRNode node)
    {
        manoIzq.transform.position = manoIzquierda.transform.position;
        manoDch.transform.position = manoDerecha.transform.position;
    }

    public void EsLocal()
    {
        manoIzquierda.enabled = true;
        manoDerecha.enabled = true;
        player.enabled = true;
        camara.enabled = true;

        manoIzq.gameObject.GetComponent<FollowHand>().enabled = true;
        manoDch.gameObject.GetComponent<FollowHand>().enabled = true;
    }
}
