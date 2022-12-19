using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Subtitulos : MonoBehaviour
{
    public TMP_Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequenceNave());
    }

    public void IniciarSala()
    {
        StartCoroutine(TheSequenceSala());
    }

    public void IniciarTaller()
    {
        StartCoroutine(TheSequenceTrampilla());
    }

    IEnumerator TheSequenceNave()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Nos aproximamos a la luna";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Pavel: Hay que prepararse";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Correcto vayamos al modulo lunar";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Mision: Encuentra la forma para llegar al modulo lunar";
        yield return new WaitForSeconds(8);
        textBox.text = "";
    }

    IEnumerator TheSequenceSala()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Maldita sea la puerta se ha cerrado";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Pavel: Como pasamos?";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Miremos la caja de fusibles";
        yield return new WaitForSeconds(5);
        textBox.text = "";
    }

    IEnumerator TheSequenceTrampilla()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Vale antes de salir hay";
        yield return new WaitForSeconds(5);
        textBox.text = "que solucionar unas cuantas cosas";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Pavel: Reparar la liada de la electricidad,";
        yield return new WaitForSeconds(5);
        textBox.text = "cargar el modulo...";
        yield return new WaitForSeconds(5);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Venga vamos a ello";
        yield return new WaitForSeconds(4);
        textBox.text = "";
    }



    IEnumerator TheSequenceDesacopleModuloLunar()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Pulsa el boton para desacoplar el modulo lunar de la nave";
        yield return new WaitForSeconds(4);
        textBox.text = "";
    }

    IEnumerator TheSequenceModuloLunar()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Maldita sea hay que corregir el rumbo";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Pavel: Yo me ocupo de la velocidad";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Yo me ocupo de la trayectoria";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Coordinate con tu compa�ero para aterrizar a salvo";
        yield return new WaitForSeconds(4);
        textBox.text = "";
    }
}
