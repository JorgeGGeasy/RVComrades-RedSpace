using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Valve.VR;

public class SyncHands : MonoBehaviourPun, IPunObservable
{
    public SteamVR_Action_Pose poseAction; // Acción de posición de SteamVR
    public SteamVR_Input_Sources handType; // Tipo de mano (izquierda o derecha)
    private Vector3 currentPosition; // Posición actual de la mano
    private Quaternion currentRotation; // Rotación actual de la mano

    void Start()
    {
        // Si eres el dueño del objeto, inicializa su posición y rotación actuales
        if (photonView.IsMine)
        {
            currentPosition = transform.localPosition;
            currentRotation = transform.localRotation;
        }
    }

    void Update()
    {
        // Si eres el dueño del objeto, actualiza su posición y rotación según la acción de posición de SteamVR
        if (photonView.IsMine)
        {
            transform.localPosition = poseAction.GetLocalPosition(handType);
            transform.localRotation = poseAction.GetLocalRotation(handType);
        }
    }

    // Esta función se llama cuando se recibe una actualización del estado del objeto a través de Photon
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Si estamos enviando datos al servidor...
        if (stream.IsWriting)
        {
            // Envía la posición y rotación actuales del objeto al servidor
            Debug.Log("Enviando datos");
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
        }
        // Si estamos recibiendo datos del servidor...
        else
        {
            Debug.Log("Recibiendo datos");
            // Recibe la posición y rotación actualizadas del servidor y las asigna al objeto
            currentPosition = (Vector3)stream.ReceiveNext();
            currentRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
