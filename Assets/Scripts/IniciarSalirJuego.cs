using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarSalirJuego : MonoBehaviour
{
    public void IniciarJuego()
    {
        Debug.Log("Entrando");
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}

