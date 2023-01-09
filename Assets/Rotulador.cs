using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class Rotulador : MonoBehaviour
{
    public Transform punta;
    public int tamaņoPunta = 5;

    private Renderer renderer;
    private Color[] colores;
    private float alturaPunta;
    private RaycastHit tocarPizarra;
    private Pizarra pizarra;

    private Vector2 tocarPizarraPos;
    private Vector2 ultimoToquePos;
    private bool tocarUltimoFrame;
    private Quaternion ultimoToqueRot;

    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        renderer = punta.GetComponent<Renderer>();
        colores = Enumerable.Repeat(renderer.material.color, tamaņoPunta * tamaņoPunta).ToArray();
        alturaPunta = punta.localScale.y/6f;
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        photonView.RPC("Dibujar", RpcTarget.All);
    }

    [PunRPC]
    private void Dibujar()
    {
        if (Physics.Raycast(punta.position, transform.forward * -1, out tocarPizarra, alturaPunta / 3f))
        {
            if (tocarPizarra.transform.CompareTag("Pizarra"))
            {
                if (pizarra == null)
                {
                    pizarra = tocarPizarra.transform.GetComponent<Pizarra>();
                }

                tocarPizarraPos = new Vector2(tocarPizarra.textureCoord.x, tocarPizarra.textureCoord.y);

                int x = (int)(tocarPizarraPos.x * pizarra.textureSize.x - (tamaņoPunta / 2));
                int y = (int)(tocarPizarraPos.y * pizarra.textureSize.y - (tamaņoPunta / 2));

                if (y < 0 || y > pizarra.textureSize.y || x < 0 || x > pizarra.textureSize.x)
                    return;

                if (tocarUltimoFrame)
                {
                    pizarra.texture.SetPixels(x, y, tamaņoPunta, tamaņoPunta, colores);

                    for (float f = 0.01f; f < 1; f += 0.03f)
                    {
                        int lerpX = (int)Mathf.Lerp(ultimoToquePos.x, x, f);
                        int lerpY = (int)Mathf.Lerp(ultimoToquePos.y, y, f);
                        pizarra.texture.SetPixels(lerpX, lerpY, tamaņoPunta, tamaņoPunta, colores);
                    }

                    transform.rotation = ultimoToqueRot;
                    pizarra.texture.Apply();
                }
                ultimoToquePos = new Vector2(x, y);
                ultimoToqueRot = transform.rotation;
                tocarUltimoFrame = true;
                return;
            }
        }
        pizarra = null;
        tocarUltimoFrame = false;
    }
}
