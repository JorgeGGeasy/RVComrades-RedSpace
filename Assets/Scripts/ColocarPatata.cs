using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColocarPatata : MonoBehaviour
{
    [SerializeField]
    float radio;

    [SerializeField]
    GameObject patataCaja;

    [SerializeField]
    private Color colorLuz;

    [SerializeField]
    private AudioClipManager audioClipManager;

    [SerializeField]
    private AudioSource audioClipManagerFondo;

    public bool patataColocada = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!patataColocada)
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radio);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Patata")
                {
                    Debug.Log("Patata");
                    patataCaja.gameObject.SetActive(true);
                    hitCollider.gameObject.SetActive(false);
                    patataColocada = true;
                    StartCoroutine(AnimacionEncenderLuces());
                }
            }
        }
    }


     IEnumerator AnimacionEncenderLuces(){

        // ------------------
        GameObject[] luces =  GameObject.FindGameObjectsWithTag("Luces");
        GameObject[] linternas =  GameObject.FindGameObjectsWithTag("Linterna");
        bool boolParpadear = false;

        // TODO sonido de apagar generador
        // Audio encendiendose motores
        audioClipManager.SeleccionarAudio(4, 0.1f);
        encenderLuces(luces,linternas);
        
        //parpadear Luces
        for(int i = 0; i<6; i++){
            parpadearLuces(luces,boolParpadear);
            boolParpadear = !boolParpadear;
            audioClipManager.SeleccionarAudio(3, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }


        yield return new WaitForSeconds(4f);
        audioClipManagerFondo.UnPause();

    }

    private void parpadearLuces(GameObject[] luces, bool encender){
        

        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = encender ? 1.6f : 0.6f;
        }
    }

    private void encenderLuces(GameObject[] luces,GameObject[] linternas){
    
        foreach(GameObject luz in luces){
            luz.GetComponent<Light>().intensity = 2.6f;
            luz.GetComponent<Light>().color = colorLuz;
        }

        foreach(GameObject linterna in linternas){
            linterna.GetComponent<Light>().intensity = 0.0f;
        }
    }
}
