using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovediza : MonoBehaviour {

    public Rigidbody2D rbPlataformaMovediza;
    public float distancia, velocidad;

    private float posInicio, posFinal;

    private bool isFlip = false;
    // Use this for initialization
    void Start () {
        rbPlataformaMovediza = GetComponent<Rigidbody2D>();
        posInicio = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        movimiento();
        posFinal = transform.position.x;
        distancia = posFinal - posInicio;
    }

    void movimiento()
    {
        if (isFlip == false)
        {
            if (distancia >= 5f)
            {
                rbPlataformaMovediza.velocity = new Vector2((velocidad * -1) * Time.deltaTime, rbPlataformaMovediza.velocity.y);
                isFlip = true;
            }
            else
            {
                rbPlataformaMovediza.velocity = new Vector2(velocidad * Time.deltaTime, rbPlataformaMovediza.velocity.y);
                isFlip = false;
            }
        }
        else
        {
            if (distancia <= 0f)
            {
                rbPlataformaMovediza.velocity = new Vector2((velocidad) * Time.deltaTime, rbPlataformaMovediza.velocity.y);
                isFlip = false;
            }
            else
            {
                rbPlataformaMovediza.velocity = new Vector2((velocidad * -1) * Time.deltaTime, rbPlataformaMovediza.velocity.y);
                isFlip = true;
            }
        }
    }
}
