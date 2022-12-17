using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepararObjetos : MonoBehaviour
{

    [SerializeField]
    GameObject[] objetosNecesarios;

    int contador;

    public bool objetos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(objetosNecesarios.Length);
        foreach(GameObject objetoNecesario in objetosNecesarios)
        {
            if (c.gameObject == objetoNecesario && !objetos)
            {
                Debug.Log("Colision");
                objetoNecesario.SetActive(false);
                contador++;                
            }
        }

        if (contador == objetosNecesarios.Length)
        {
            objetos = true;
        }

    }
}
