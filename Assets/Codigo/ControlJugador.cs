using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour {

    public GameObject cuchilla, cuchilla2, cuchilla3, cuchilla4, cuchilla5, puertaSalida;

    public Rigidbody2D rbJugador;

    public float velocidadY, radioZonaPiso;
    public float velocidadMovimiento;
    public LayerMask tocarPiso;
    private bool esPiso, dobleSalto;
    public Transform zonaPiso;
    
    private bool morir, disparo;

    public static float ultimaPosJugador;
    private float posJugadorY;

    public float timeInicio = 0f;
    public float timeMuerte=0f;
    public float timeTranscursoMuerte = 0f;
    public float timeTerminaAnimacion = 0f;

    //Creamos una variable pública donde asignar nuestro prefab 'Proyectil'
    public GameObject ProyectilPrefab;//Cambiar bala por bola 

    public static int numBalas=6;
    public static int puntaje=0;
    public Text lblBalas;
    public Text lblPuntaje;
    public GameObject imgGanaste;

    //Barra de vida
    public Scrollbar barraVida;
    public static float vidaJugador = 100f;
    private float tiempoMuerte;
    

    // Use this for initialization
    void Start () {
        rbJugador = GetComponent<Rigidbody2D>();
        morir = false;
        disparo = false;
        puertaSalida.SetActive(false);
        imgGanaste.SetActive(false);
    }

    private void LateUpdate()
    {
        if (tiempoMuerte > 1.65){
            puntaje = 0;
            numBalas = 6;
            vidaJugador = 100f;
            SceneManager.LoadScene("Nivel1");
        }    
    }

    // Update is called once per frame
    void Update () {
        esPiso = Physics2D.OverlapCircle(zonaPiso.position, radioZonaPiso, tocarPiso);
        if (esPiso)
            dobleSalto = false;
        
        movimiento();
        girarCuchilla();
        Salto();
        disparar();
        muere();

        var ultimaPosJug = transform.position;
        ultimaPosJugador = ultimaPosJug.x;
        posJugadorY = ultimaPosJug.y;

        timeInicio += Time.deltaTime;
        timeTranscursoMuerte = timeInicio - timeMuerte;

        lblPuntaje.text = puntaje+" Puntos"; 
        lblBalas.text = numBalas +" Balas";

        barraVida.size = vidaJugador/100f;
    }

    void girarCuchilla()
    {
        cuchilla.transform.Rotate(0, 0, 250 * Time.deltaTime);
        cuchilla2.transform.Rotate(0, 0, 280 * Time.deltaTime);
        cuchilla3.transform.Rotate(0, 0, 320 * Time.deltaTime);
        cuchilla4.transform.Rotate(0, 0, 350 * Time.deltaTime);
        cuchilla5.transform.Rotate(0, 0, 350 * Time.deltaTime);
    }

    void Salto()
    {
        if (Input.GetButtonDown("Jump") && esPiso)
            rbJugador.velocity = new Vector2(rbJugador.velocity.x, velocidadY);
        if (Input.GetButtonDown("Jump") && !esPiso && !dobleSalto)
        {
            rbJugador.velocity = new Vector2(rbJugador.velocity.x,velocidadY);
            dobleSalto = true;
        }
        gameObject.GetComponent<Animator>().SetFloat("velocidadY", Mathf.Abs(rbJugador.velocity.y));
    }
    
    void movimiento() {
        float inputX = Input.GetAxis("Horizontal");
        if (inputX > 0)
        {
            rbJugador.velocity = new Vector2(velocidadMovimiento * inputX * Time.deltaTime, rbJugador.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (inputX < 0)
        {
            rbJugador.velocity = new Vector2(velocidadMovimiento * inputX * Time.deltaTime, rbJugador.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        gameObject.GetComponent<Animator>().SetFloat("velocidadX", Mathf.Abs(inputX));
    }

    void muere() {
        if (vidaJugador<=0) {
            morir = true;
            gameObject.GetComponent<Animator>().SetBool("jugadorMuere", morir);
            tiempoMuerte += Time.deltaTime;
        }
        
    }

    void disparar()
    {
        if (numBalas>0) { 
        if (Input.GetKeyDown(KeyCode.LeftControl)){

            disparo = true;
            //Accedemos al script 'ArmaArrojadiza.cs' del prefab
            Proyectil scriptProyectil = ProyectilPrefab.GetComponent<Proyectil>();
            var positionBala=transform.position;
            
            float positionBalaX = positionBala.x;
            float positionBalaY = positionBala.y;

            Vector2 posicionBala = new Vector2(positionBalaX, positionBalaY);

                

            if (Input.GetAxis("Vertical") > 0)
            {
                //Ataque hacia arriba
                scriptProyectil.DireccionArma = Direccion.Vertical;
                scriptProyectil.Velocidad = Math.Abs(scriptProyectil.Velocidad);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                //Ataque hacia abajo
                scriptProyectil.DireccionArma = Direccion.Vertical;
                scriptProyectil.Velocidad = -Math.Abs(scriptProyectil.Velocidad);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                //Ataque hacia la derecha
                scriptProyectil.DireccionArma = Direccion.Horizontal;
                scriptProyectil.Velocidad = Math.Abs(scriptProyectil.Velocidad);
                positionBalaX += 1.4f;
                positionBalaY += 0.4f;
                posicionBala = new Vector2 (positionBalaX, positionBalaY);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                //Ataque hacia la izquierda
                scriptProyectil.DireccionArma = Direccion.Horizontal;
                scriptProyectil.Velocidad = -Math.Abs(scriptProyectil.Velocidad);
                scriptProyectil.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                positionBalaX -= 1.4f;
                positionBalaY -= 0.4f;
                posicionBala = new Vector2 (positionBalaX, positionBalaY);
            }

            //Creamos una instancia del prefab en nuestra escena, concretamente en la posición de nuestro personaje
            Instantiate(scriptProyectil, posicionBala, Quaternion.identity);
            numBalas--;
        }
        }
        gameObject.GetComponent<Animator>().SetBool("disparar", disparo);
        disparo = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Chuzos")
        {
            vidaJugador -= 100;
        }
        if (other.gameObject.tag == "Cuchillas")
        {
            vidaJugador -= 10;
            rbJugador.velocity = new Vector2(velocidadMovimiento * -1.5f * Time.deltaTime, rbJugador.velocity.y);
        }
        if (other.gameObject.tag=="zombienmuertos") {
            vidaJugador -= 20;
        }
        if (other.gameObject.tag == "zombienmuertosmujer")
        {
            vidaJugador -= 20;
        }
        if (other.gameObject.tag == "zombiengrandes")
        {
            vidaJugador -= 40;
        }
        if (other.gameObject.tag == "SwitchSalida")
        {
            puertaSalida.SetActive(true);
            imgGanaste.SetActive(true);
        }
    }
}
