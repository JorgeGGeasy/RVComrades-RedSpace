using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Valve.VR.InteractionSystem
{
    public class NetworkCircularDrive : CircularDrive
    {
    
       private PhotonView photonView;
    
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            photonView = GetComponent<PhotonView>();
        }


        /*protected override void UpdateAll(){

            
            base.UpdateAll();
            /*float linearValue = linearMapping.value;
            Quaternion startTEMP = start;
            Vector3 localPlaneNormalTEMP = localPlaneNormal;
            photonView.RPC("UpdateLinearMappingSync", RpcTarget.All,linearValue,start,localPlaneNormal);

        
        }

        [PunRPC]
        private void UpdateLinearMappingSync(float linearValue, Quaternion startTEMP, Vector3 localPlaneNormalTEMP){
           linearMapping.value = linearValue;
           start = startTEMP;
           localPlaneNormal = localPlaneNormalTEMP;
           base.UpdateGameObject();
        }*/
    }
}
