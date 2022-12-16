using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoz : MonoBehaviour
{

    private Vector3 previousPosition;
    private float velocidad;
    
    private void Update() {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 v3Velocity = rb.velocity; 
        velocidad = Vector3.Magnitude(rb.velocity);
    }
    
    public float GetVelocidad() {
        return velocidad;
    }
}
