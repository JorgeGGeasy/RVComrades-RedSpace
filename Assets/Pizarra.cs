using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizarra : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC("StartPizarra", RpcTarget.All);
    }

    [PunRPC]
    void StartPizarra()
    {
        Renderer renderer = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        renderer.material.mainTexture = texture;
    }
}
