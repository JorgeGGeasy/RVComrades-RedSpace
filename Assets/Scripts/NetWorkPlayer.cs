using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Valve.VR.Extras;


namespace Valve.VR.InteractionSystem
{
    public class NetWorkPlayer : MonoBehaviour
    {
        public Transform head;
        public Transform leftHand;
        public Transform rightHand;
        private PhotonView photonView;

        public Transform headRig;
        private Transform leftHandRig;
        private Transform rightHandRig;

        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();

            Player player = FindObjectOfType<Player>();

            headRig = player.transform.Find("SteamVRObjects/VRCamera");
            //headRig = player.transform.Find("NoSteamVRFallbackObjects/FallbackObjects");
            leftHandRig = player.transform.Find("SteamVRObjects/LeftHand");
            rightHandRig = player.transform.Find("SteamVRObjects/RightHand");

        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                rightHand.gameObject.SetActive(false);
                leftHand.gameObject.SetActive(false);
                head.gameObject.SetActive(false);


                MapPosition(head, headRig);
                MapPosition(leftHand, leftHandRig);
                MapPosition(rightHand, rightHandRig);
            }
        }

        void MapPosition(Transform target, Transform rig)
        {
            //target.position = rig.position;
            //target.rotation = rig.rotation;

        }
    }

}