using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RecibirGolpe : MonoBehaviour
{

    public UnityEvent myEvent;

    private bool entrarBool = true;

    private bool pulsarBool = true;

    [SerializeField]
    private Objeto objeto;

    private bool pulsarIndex;
    /*
    private void OnEnable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.RegisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.UnregisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.UnregisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }
    private void OnPositionBroadcast(PositionIndex indexStruct)
    {
        pulsarIndex = indexStruct.pIndex;
    }

    private void OnClientPositionBroadcast(NetworkConnection networkConnection, PositionIndex indexStruct)
    {
        InstanceFinder.ServerManager.Broadcast(indexStruct);
    }

    public void OnPointerClickObject()
    {
        if (pulsarBool)
        {
            if (InstanceFinder.IsServer)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            else if (InstanceFinder.IsClient)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            PulsarServer();
        }
    }
    [ServerRpc(RequireOwnership = false)]   
    void PulsarServer()
    {
        PulsarObserver();
    }

    [ObserversRpc]
    void PulsarObserver()
    {
        StartCoroutine(Pulsar());
    }

    IEnumerator Pulsar()
    {
        pulsarBool = false;
        myEvent.Invoke();
        // Aqui sacamos el tipo de objeto y ejecutamos su interacción.

        if (objeto.boton)
        {
            this.GetComponent<Animator>().SetTrigger("Pressed");
        }


        yield return new WaitForSeconds(1f);
        pulsarBool = true;
    }

    public struct PositionIndex : IBroadcast
    {
        public bool pIndex;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
