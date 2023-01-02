using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Valve.VR.InteractionSystem
{
    public class NetworkCircularDrive : CircularDrive
    {
    
        private PhotonView photonView;
        private float linearValue;
    
        // Start is called before the first frame update
        void Start()
        {
            
                photonView = GetComponent<PhotonView>();
        }


        protected override void UpdateAll(){

            
            base.UpdateAll();
            linearValue = linearMapping.value;
            //photonView.RPC("UpdateLinearMappingSync", RpcTarget.All,linearValue);

        
        }

        [PunRPC]
        private void UpdateLinearMappingSync(float linearValue){
           linearMapping.value = linearValue;
           base.UpdateAll();
        }
    }
}
