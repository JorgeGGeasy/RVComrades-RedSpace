using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class subtitulos : MonoBehaviour
{
    public TMP_Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequenceNave());
    }

    IEnumerator TheSequenceNave()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Nos aproximamos a la luna";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Pavel: Devemos de prepararnos";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Maksim: Correcto vayamos al modulo lunar";
        yield return new WaitForSeconds(4);
        textBox.text = "";
        yield return new WaitForSeconds(1);
        textBox.text = "Encuentra la forma para llegar al modulo lunar";
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
        textBox.text = "Coordinate con tu compañero para aterrizar a salvo";
        yield return new WaitForSeconds(4);
        textBox.text = "";
    }
}
