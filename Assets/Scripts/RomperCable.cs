using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperCable : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radio);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.gameObject == objetoParaRomperCables)
            {
                    Debug.Log("Colision");
            }


        }*/
        
    }

    void OnTriggerEnter(Collider c) 
    {
        if(c.gameObject == objetoParaRomperCables && !roto){
            Debug.Log("Colision");
            roto = true;

            // animacion de romper cables
            StartCoroutine(AnimacionRomperCables());

           
        }
    }

    IEnumerator AnimacionRomperCables(){

        // ------------------
        GameObject[] luces =  GameObject.FindGameObjectsWithTag("Luces");
        GameObject[] linternas =  GameObject.FindGameObjectsWithTag("Linterna");
        bool boolParpadear = false;

        // romper cables --------------------------------
        romperCables.Play("RomperCablesFusibles");
        yield return new WaitForSeconds(1.0f);
  
        
        //parpadear Luces
        for(int i = 0; i<6; i++){
            parpadearLuces(luces,boolParpadear);
            boolParpadear = !boolParpadear;
            yield return new WaitForSeconds(0.1f);
        }

        // TODO sonido de apagar generador
        apagarLuces(luces,linternas);
        audioClipManager.SeleccionarAudio(0,0.5f);

        // abrir puerta ------------
        puerta.GetComponent<Animator>().Play("Puerta");
        yield return new WaitForSeconds(1f);
        puerta.GetComponent<Animator>().enabled = false; // parar animacion
    }

    private void parpadearLuces(GameObject[] luces, bool encender){
        

        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = encender ? 1.6f : 0.6f;
        }
    }

    private void apagarLuces(GameObject[] luces,GameObject[] linternas){
    
        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = 0.6f;
            luz.GetComponent<Light>().color = colorRojoLuz;
        }

        foreach(GameObject linterna in linternas){
            linterna.GetComponent<Light>().intensity = 3.0f;
        }
    }

   
    

 
}
