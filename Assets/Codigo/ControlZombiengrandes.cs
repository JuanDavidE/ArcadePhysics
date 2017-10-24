using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZombiengrandes : MonoBehaviour {

    public Rigidbody2D rbZombieHombre;
    public float distancia, velocidadZombie, distanciaRecorrido;

    private float posInicio, posFinal;
    public int vidas;

    private bool isFlip = false;
    private bool atacar = false;
    private bool murio;

    public float tiempoMuerte = 0;

    // Use this for initialization
    void Start()
    {
        rbZombieHombre = GetComponent<Rigidbody2D>();
        posInicio = transform.position.x;
        vidas = 6;
    }

    // Update is called once per frame
    void Update()
    {

        movimiento();
        posFinal = transform.position.x;
        distancia = posFinal - posInicio;
        morir();
    }

    void LateUpdate()
    {
        if (tiempoMuerte > 1.65)
        {
            gameObject.SetActive(false);
            ControlJugador.puntaje += 50;
        }
    }

    void movimiento()
    {
        if (murio == false)
        {
            if (posFinal - ControlJugador.ultimaPosJugador <= 2 && posFinal - ControlJugador.ultimaPosJugador >= -2)
            {
                atacar = true;
            }
            else atacar = false;
            //velocidadZombie = 50f;
            if (isFlip == false)
            {
                if (distancia >= distanciaRecorrido)
                {
                    rbZombieHombre.velocity = new Vector2((velocidadZombie * -1) * Time.deltaTime, rbZombieHombre.velocity.y);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    isFlip = true;
                }
                else
                {
                    rbZombieHombre.velocity = new Vector2(velocidadZombie * Time.deltaTime, rbZombieHombre.velocity.y);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    isFlip = false;
                }
            }
            else
            {
                if (distancia <= 0f)
                {
                    rbZombieHombre.velocity = new Vector2((velocidadZombie) * Time.deltaTime, rbZombieHombre.velocity.y);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    isFlip = false;
                }
                else
                {
                    rbZombieHombre.velocity = new Vector2((velocidadZombie * -1) * Time.deltaTime, rbZombieHombre.velocity.y);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    isFlip = true;
                }
            }
            gameObject.GetComponent<Animator>().SetFloat("velocidadZombie", Mathf.Abs(velocidadZombie));

            gameObject.GetComponent<Animator>().SetBool("atacar", atacar);
        }
    }

    void morir()
    {
        if (vidas < 1)
        {
            murio = true;
            gameObject.GetComponent<Animator>().SetBool("morir", murio);
            tiempoMuerte += Time.deltaTime;
        }
    }
}
