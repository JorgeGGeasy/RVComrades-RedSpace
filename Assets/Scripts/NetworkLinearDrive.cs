using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Valve.VR.InteractionSystem
{
    public class NetworkLinearDrive : LinearDrive
    {
    
        private PhotonView photonView;
        private Transform updateTransformTEMP;
    
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

            updateTransformTEMP = updateTransform;
            photonView.RPC("UpdateLinearMappingSync", RpcTarget.All);
            

        
        }

        [PunRPC]
        private void UpdateLinearMappingSync(){
            linearMapping.value = Mathf.Clamp01( initialMappingOffset + CalculateLinearMapping( updateTransformTEMP ) );

            mappingChangeSamples[sampleCount % mappingChangeSamples.Length] = ( 1.0f / Time.deltaTime ) * ( linearMapping.value - prevMapping );
            sampleCount++;

            if ( repositionGameObject )
            {
                transform.position = Vector3.Lerp( startPosition.position, endPosition.position, linearMapping.value );
            }
        }
    }
}
