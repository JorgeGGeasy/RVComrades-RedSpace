using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColocarPatata : MonoBehaviour
{
    [SerializeField]
    float radio;

    [SerializeField]
    GameObject patataCaja;

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
                }
            }
        }
    }
}
