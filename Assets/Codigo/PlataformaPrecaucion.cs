using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPrecaucion : MonoBehaviour
{
    public Rigidbody2D rbPlataformaPrecaucion;
    public float tiempoJugador = 0f;
    private bool tocaJugador = false;

    // Use this for initialization
    void Start()
    {
        rbPlataformaPrecaucion = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().Sleep();
        rbPlataformaPrecaucion.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tocaJugador == true) {
            tiempoJugador += Time.deltaTime;
        }
        if (tiempoJugador > 1f && tiempoJugador<3f) {
            rbPlataformaPrecaucion.isKinematic = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            tocaJugador = true;
        }
        if (other.gameObject.tag == "Chuzos")
        {
            gameObject.SetActive(false);
        }
    }
}