using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Valve.VR;

public class SyncHands : MonoBehaviourPun, IPunObservable
{
    public SteamVR_Action_Pose poseAction; // Acci�n de posici�n de SteamVR
    public SteamVR_Input_Sources handType; // Tipo de mano (izquierda o derecha)
    private Vector3 currentPosition; // Posici�n actual de la mano
    private Quaternion currentRotation; // Rotaci�n actual de la mano

    void Start()
    {
        // Si eres el due�o del objeto, inicializa su posici�n y rotaci�n actuales
        if (photonView.IsMine)
        {
            currentPosition = transform.localPosition;
            currentRotation = transform.localRotation;
        }
    }

    void Update()
    {
        // Si eres el due�o del objeto, actualiza su posici�n y rotaci�n seg�n la acci�n de posici�n de SteamVR
        if (photonView.IsMine)
        {
            transform.localPosition = poseAction.GetLocalPosition(handType);
            transform.localRotation = poseAction.GetLocalRotation(handType);
        }
    }

    // Esta funci�n se llama cuando se recibe una actualizaci�n del estado del objeto a trav�s de Photon
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Si estamos enviando datos al servidor...
        if (stream.IsWriting)
        {
            // Env�a la posici�n y rotaci�n actuales del objeto al servidor
            Debug.Log("Enviando datos");
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
        }
        // Si estamos recibiendo datos del servidor...
        else
        {
            Debug.Log("Recibiendo datos");
            // Recibe la posici�n y rotaci�n actualizadas del servidor y las asigna al objeto
            currentPosition = (Vector3)stream.ReceiveNext();
            currentRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
