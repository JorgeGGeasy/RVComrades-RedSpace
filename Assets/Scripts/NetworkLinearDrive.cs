using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Valve.VR.InteractionSystem
{
    public class NetworkLinearDrive : LinearDrive
    {
    
        private PhotonView photonView;
        private float linearValue;
    
        // Start is called before the first frame update
        void Start()
        {
            
                photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        protected override void UpdateLinearMapping(Transform updateTransform ){

            
            base.UpdateLinearMapping(updateTransform);
            linearValue = linearMapping.value;
            photonView.RPC("UpdateLinearMappingSync", RpcTarget.All,linearValue);

        
        }

        [PunRPC]
        private void UpdateLinearMappingSync(float linearValue){
            linearMapping.value = linearValue;

            mappingChangeSamples[sampleCount % mappingChangeSamples.Length] = ( 1.0f / Time.deltaTime ) * ( linearValue - prevMapping );
            sampleCount++;

            if ( repositionGameObject )
            {
                transform.position = Vector3.Lerp( startPosition.position, endPosition.position, linearValue );
            }
        }
    }
}
