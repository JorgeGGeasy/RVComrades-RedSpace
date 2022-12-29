using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RomperCable : MonoBehaviourPunCallbacks
{


    [SerializeField]
    private GameObject objetoParaRomperCables;
    [SerializeField]
    private Animator romperCables;

    [SerializeField]
    private Color colorRojoLuz;

    [SerializeField]
    private GameObject puerta;

    private bool roto = false;


    [SerializeField]
    private AudioClipManager audioClipManager;

    [SerializeField]
    private AudioSource audioClipManagerFondo;

    [SerializeField]
    Subtitulos subtitulos;

    private PhotonView photonView;
    // variables globales porque las funciones PUNRCP no se le pueden pasar parametros
    private GameObject[] luces;
    private GameObject[] linternas;
    private bool boolParpadear;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        luces =  GameObject.FindGameObjectsWithTag("Luces");
        linternas =  GameObject.FindGameObjectsWithTag("Linterna");
    }

    

    void OnTriggerEnter(Collider c) 
    {
        if(c.gameObject == objetoParaRomperCables && !roto){
            // animacion de romper cables
            StartCoroutine(AnimacionRomperCables());

           
        }
    }

    IEnumerator AnimacionRomperCables(){

        // ------------------
        
        boolParpadear = false;

        // romper cables --------------------------------
        photonView.RPC("animarCables", RpcTarget.All);
        
        // TODO sonido de apagar generador
        photonView.RPC("PlayApagarLuces", RpcTarget.All);
        yield return new WaitForSeconds(1.0f);

        
        //parpadear Luces
        for (int i = 0; i<6; i++){
            photonView.RPC("parpadearLuces", RpcTarget.All);
            photonView.RPC("PlayClick", RpcTarget.All);
            yield return new WaitForSeconds(0.1f);
        }
        photonView.RPC("ApagarMusicaFondo", RpcTarget.All);
       

        photonView.RPC("apagarLuces", RpcTarget.All);
        

        // abrir puerta ------------
        photonView.RPC("animarPuerta", RpcTarget.All);
        photonView.RPC("PlayPuerta", RpcTarget.All);
        yield return new WaitForSeconds(1f);
        photonView.RPC("pararPuerta", RpcTarget.All);
        
    }

    /// funciones PUNRPCS para el audio 
    [PunRPC]
    void PlayClick()
    {
        audioClipManager.SeleccionarAudio(3, 0.5f);
    }

    [PunRPC]
    void PlayPuerta()
    {
        audioClipManager.SeleccionarAudio(2, 0.5f);
    }

    [PunRPC]
    void PlayApagarLuces()
    {
        audioClipManager.SeleccionarAudio(0, 0.5f);
    }

    [PunRPC]
    void ApagarMusicaFondo()
    {
        audioClipManagerFondo.Pause();
    }


    // funciones PUNRPC luces
    [PunRPC]
    private void parpadearLuces(){
        

        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = boolParpadear ? 1.6f : 0.6f;
            boolParpadear = !boolParpadear;
        }
    }

    [PunRPC]
    private void apagarLuces(){
    
        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = 0.6f;
            luz.GetComponent<Light>().color = colorRojoLuz;
        }

        foreach(GameObject linterna in linternas){
            linterna.GetComponent<Light>().intensity = 3.0f;
        }
    }

   // funciones PUNRPC animaciones
    [PunRPC]
    private void animarPuerta(){
        puerta.GetComponent<Animator>().Play("Puerta");
    }

    [PunRPC]
    private void pararPuerta(){
        puerta.GetComponent<Animator>().enabled = false; // parar animacion
        subtitulos.IniciarTaller();
    }

    [PunRPC]
    private void animarCables(){
        roto = true;
        romperCables.Play("RomperCablesFusibles");
    }

 
}
