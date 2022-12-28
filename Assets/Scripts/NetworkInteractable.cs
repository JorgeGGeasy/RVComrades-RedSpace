using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
    public class NetworkInteractable : Interactable
    {
        private PhotonView photonView;
        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override void OnAttachedToHand(Hand hand)
        {
            photonView.RequestOwnership();
            base.OnAttachedToHand(hand);
        }
    }
}
