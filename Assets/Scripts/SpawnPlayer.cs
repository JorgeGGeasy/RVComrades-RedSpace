using FishNet;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Observing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpawnPlayer : NetworkBehaviour
{

    public override void OnStartClient()
    {
        base.OnStartClient();
        SpawnCliente();
    }

    public void SpawnCliente()
    {
        Debug.Log("Jugador Spawneado");
        if (base.IsOwner)
        {
            Debug.Log("Soy tuyo");
        }
        else
        {
            Debug.Log("No sos el dueño master");
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<NetworkObserver>().enabled = false;
            gameObject.GetComponentInChildren<Camera>().enabled = false;
        }
    }

    public void Respawn(string sceneName)
    {
        List<NetworkObject> nobs = new List<NetworkObject>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            nobs.Add(player.GetComponent<NetworkObject>());
        }
        SceneLoadData sld = new SceneLoadData(sceneName);
        sld.MovedNetworkObjects = nobs.ToArray();
        sld.ReplaceScenes = ReplaceOption.All;
        InstanceFinder.SceneManager.LoadGlobalScenes(sld);
        InstanceFinder.SceneManager.OnLoadEnd += SceneManager_OnLoadEnd;
    }

    private void SceneManager_OnLoadEnd(SceneLoadEndEventArgs obj)
    {
        StartCoroutine(Respawnear());
    }

    IEnumerator Respawnear()
    {
        GameObject[] jugadores = GameObject.FindGameObjectsWithTag("Player");

        if (jugadores[0].GetComponent<NetworkObject>().IsOwner)
        {
            RespawnPlayer(jugadores[0].gameObject.GetComponent<NetworkObject>().Owner, jugadores[0].gameObject, GameObject.FindGameObjectsWithTag("Spawnpoint")[0].transform.position);
        }
        else
        {
            RespawnServer(jugadores[0].gameObject, GameObject.FindGameObjectsWithTag("Spawnpoint")[0].transform.position);
        }

        yield return new WaitForSeconds(0.3f);

        if (jugadores[1].GetComponent<NetworkObject>().IsOwner)
        {
            RespawnPlayer(jugadores[1].gameObject.GetComponent<NetworkObject>().Owner, jugadores[1].gameObject, GameObject.FindGameObjectsWithTag("Spawnpoint")[1].transform.position);
        }
        else
        {
            RespawnServer(jugadores[1].gameObject, GameObject.FindGameObjectsWithTag("Spawnpoint")[1].transform.position);
        }
    }

    [TargetRpc]
    void RespawnPlayer(NetworkConnection conn, GameObject player, Vector3 spawnPos)
    {
        int jugadores = GameObject.FindGameObjectsWithTag("Player").Length - 1;
        if (base.IsOwner)
        {
            Debug.Log("Me muevo");
            player.transform.position = spawnPos;
        }

    }

    [ServerRpc]
    void RespawnServer(GameObject player, Vector3 spawnPos)
    {
        RespawnObserver(player, spawnPos);
    }

    [ObserversRpc]
    void RespawnObserver(GameObject player, Vector3 spawnPos)
    {
        Debug.Log("Me muevo en server");
        Debug.Log(player.GetComponent<NetworkObject>().IsOwner);
        player.transform.position = spawnPos;
    }
}
