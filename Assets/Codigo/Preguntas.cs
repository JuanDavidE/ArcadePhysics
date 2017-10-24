using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class Preguntas : MonoBehaviour {

    public GameObject pregunta;
    public GameObject fondoPregunta;
    public Text lblEnunciado;
    public Text btnRtaA;
    public Text btnRtaB;
    public Text btnRtaC;
    public Text btnRtaD;

    private string enunciado,rtaA, rtaB, rtaC, rtaD;
    private static string rtaCorrecta;
    private string enunciado2, rtaA2, rtaB2, rtaC2, rtaD2;
    private string enunciado3, rtaA3, rtaB3, rtaC3, rtaD3;
    private string enunciado4, rtaA4, rtaB4, rtaC4, rtaD4;
    private string enunciado5, rtaA5, rtaB5, rtaC5, rtaD5;
    private string enunciado6, rtaA6, rtaB6, rtaC6, rtaD6;
    private string enunciado7, rtaA7, rtaB7, rtaC7, rtaD7;
    private string enunciado8, rtaA8, rtaB8, rtaC8, rtaD8;
    private string enunciado9, rtaA9, rtaB9, rtaC9, rtaD9;
    private string enunciado10, rtaA10, rtaB10, rtaC10, rtaD10;
    
        // Use this for initialization
    void Start () {
        escogerAleatoria();
        asignarPregunta();
        fondoPregunta.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            fondoPregunta.SetActive(true);
            escogerAleatoria();
            Time.timeScale = 0;
            pregunta.SetActive(false);
        }
    }

    void asignarPregunta()
    {
        enunciado = "El enunciado “Un cuerpo permanece en reposo o se mueve con velocidad constante cuando la suma de las fuerzas que actúan sobre él es igual a cero” corresponde a:";
        rtaA = "Primera ley de Newton"; //Correcta
        rtaB = "Segunda ley de Newton";
        rtaC = "Tercera ley de Newton";
        rtaD = "Ley de Hooke";
        
        enunciado2 = "Diga cuál de las siguientes expresiones es correcta:";
        rtaA2 = "La masa y el peso se refieren a la misma cantidad física, solo que están expresadas en unidades diferentes";
        rtaB2 = "La masa es una propiedad de un solo objeto, mientras que el peso resulta de la interacción de dos objetos";
        rtaC2 = "El peso de un objeto es proporcional a su masa"; //Correcta
        rtaD2 = "La masa de un cuerpo varia con los cambios de su peso";

        enunciado3 = "¿Cuánto duró la guerra de los 100 años?";
        rtaA3 = "100 años";
        rtaB3 = "99 años";
        rtaC3 = "110 años";
        rtaD3 = "116 años"; //Correcta

        enunciado4 = "Se mezcla cierto volumen de agua a 65ºC con cierto volumen de agua a 15º C, obteniendo 5 gramos de agua a 35º C.Para bajar la temperatura de estos 5 gramos de agua de 35º C a 0º C permaneciendo en estado liquido, es necesario ";
        rtaA4 = "suministrarle 175 calorías "; //Correcta
        rtaB4 = "que ceda al exterior 175 calorías";
        rtaC4 = "suministrarle 35 joules de energía";
        rtaD4 = "extraerle 175 joules de energía";

        enunciado5 = "De las siguientes cantidades físicas, indique cuál es fundamental en el Sistema Internacional: ";
        rtaA5 = "Velocidad";
        rtaB5 = "Fuerza";
        rtaC5 = "Masa"; //Correcta
        rtaD5 = "Energía";

        enunciado6 = "Un tren, partiendo desde el reposo, alcanza 7.50 m/s en 10.0 s. Si su aceleración media no cambia, ¿Cuánto tiempo tarda en alcanzar una velocidad de 28.2 m/s?";
        rtaA6 = "2.66 s";
        rtaB6 = "16.2 s";
        rtaC6 = "21.2 s";
        rtaD6 = "37.6 s"; //Correcta

        enunciado7 = "¿Cuál de los siguientes enunciados es el correcto?";
        rtaA7 = "La fuerza normal y el peso NO forman un par acción-reacción, de acuerdo a la tercera ley de Newton."; //Correcta
        rtaB7 = "La fuerza normal está dada como la masa por la aceleración del cuerpo.";
        rtaC7 = "La fuerza normal y el peso forman un par acción-reacción, de acuerdo a la tercera ley de Newton.";
        rtaD7 = "La fuerza normal es igual al peso.";
    }

    void escogerAleatoria()
    {
        int pregunta = Random.Range(1,8);
        int revolverRespuesta = Random.Range(1,5);

        switch (pregunta)
        {
            case 1:
                lblEnunciado.text = enunciado;
                rtaCorrecta = rtaA;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA;
                        btnRtaB.text = rtaB;
                        btnRtaC.text = rtaC;
                        btnRtaD.text = rtaD;
                        break;
                    case 2:
                        btnRtaD.text = rtaA;
                        btnRtaC.text = rtaB;
                        btnRtaB.text = rtaC;
                        btnRtaA.text = rtaD;
                        break;
                    case 3:
                        btnRtaC.text = rtaA;
                        btnRtaD.text = rtaB;
                        btnRtaA.text = rtaC;
                        btnRtaB.text = rtaD;
                        break;
                    case 4:
                        btnRtaB.text = rtaA;
                        btnRtaA.text = rtaB;
                        btnRtaD.text = rtaC;
                        btnRtaC.text = rtaD;
                        break;
                }
                break;

            case 2:
                lblEnunciado.text = enunciado2;
                rtaCorrecta = rtaC2;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA2;
                        btnRtaB.text = rtaB2;
                        btnRtaC.text = rtaC2;
                        btnRtaD.text = rtaD2;
                        break;
                    case 2:
                        btnRtaD.text = rtaA2;
                        btnRtaC.text = rtaB2;
                        btnRtaB.text = rtaC2;
                        btnRtaA.text = rtaD2;
                        break;
                    case 3:
                        btnRtaC.text = rtaA2;
                        btnRtaD.text = rtaB2;
                        btnRtaA.text = rtaC2;
                        btnRtaB.text = rtaD2;
                        break;
                    case 4:
                        btnRtaB.text = rtaA2;
                        btnRtaA.text = rtaB2;
                        btnRtaD.text = rtaC2;
                        btnRtaC.text = rtaD2;
                        break;
                }
                break;

            case 3:
                lblEnunciado.text = enunciado3;
                rtaCorrecta = rtaD3;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA3;
                        btnRtaB.text = rtaB3;
                        btnRtaC.text = rtaC3;
                        btnRtaD.text = rtaD3;
                        break;
                    case 2:
                        btnRtaD.text = rtaA3;
                        btnRtaC.text = rtaB3;
                        btnRtaB.text = rtaC3;
                        btnRtaA.text = rtaD3;
                        break;
                    case 3:
                        btnRtaC.text = rtaA3;
                        btnRtaD.text = rtaB3;
                        btnRtaA.text = rtaC3;
                        btnRtaB.text = rtaD3;
                        break;
                    case 4:
                        btnRtaB.text = rtaA3;
                        btnRtaA.text = rtaB3;
                        btnRtaD.text = rtaC3;
                        btnRtaC.text = rtaD3;
                        break;
                }
                break;

            case 4:
                lblEnunciado.text = enunciado4;
                rtaCorrecta = rtaA4;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA4;
                        btnRtaB.text = rtaB4;
                        btnRtaC.text = rtaC4;
                        btnRtaD.text = rtaD4;
                        break;
                    case 2:
                        btnRtaD.text = rtaA4;
                        btnRtaC.text = rtaB4;
                        btnRtaB.text = rtaC4;
                        btnRtaA.text = rtaD4;
                        break;
                    case 3:
                        btnRtaC.text = rtaA4;
                        btnRtaD.text = rtaB4;
                        btnRtaA.text = rtaC4;
                        btnRtaB.text = rtaD4;
                        break;
                    case 4:
                        btnRtaB.text = rtaA4;
                        btnRtaA.text = rtaB4;
                        btnRtaD.text = rtaC4;
                        btnRtaC.text = rtaD4;
                        break;
                }
                break;

            case 5:
                lblEnunciado.text = enunciado5;
                rtaCorrecta = rtaC5;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA5;
                        btnRtaB.text = rtaB5;
                        btnRtaC.text = rtaC5;
                        btnRtaD.text = rtaD5;
                        break;
                    case 2:
                        btnRtaD.text = rtaA5;
                        btnRtaC.text = rtaB5;
                        btnRtaB.text = rtaC5;
                        btnRtaA.text = rtaD5;
                        break;
                    case 3:
                        btnRtaC.text = rtaA5;
                        btnRtaD.text = rtaB5;
                        btnRtaA.text = rtaC5;
                        btnRtaB.text = rtaD5;
                        break;
                    case 4:
                        btnRtaB.text = rtaA5;
                        btnRtaA.text = rtaB5;
                        btnRtaD.text = rtaC5;
                        btnRtaC.text = rtaD5;
                        break;
                }
                break;

            case 6:
                lblEnunciado.text = enunciado6;
                rtaCorrecta = rtaD6;

                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA6;
                        btnRtaB.text = rtaB6;
                        btnRtaC.text = rtaC6;
                        btnRtaD.text = rtaD6;
                        break;
                    case 2:
                        btnRtaD.text = rtaA6;
                        btnRtaC.text = rtaB6;
                        btnRtaB.text = rtaC6;
                        btnRtaA.text = rtaD6;
                        break;
                    case 3:
                        btnRtaC.text = rtaA6;
                        btnRtaD.text = rtaB6;
                        btnRtaA.text = rtaC6;
                        btnRtaB.text = rtaD6;
                        break;
                    case 4:
                        btnRtaB.text = rtaA6;
                        btnRtaA.text = rtaB6;
                        btnRtaD.text = rtaC6;
                        btnRtaC.text = rtaD6;
                        break;
                }
                break;

            case 7:
                lblEnunciado.text = enunciado7;
                rtaCorrecta = rtaA7;
                switch (revolverRespuesta)
                {
                    case 1:
                        btnRtaA.text = rtaA7;
                        btnRtaB.text = rtaB7;
                        btnRtaC.text = rtaC7;
                        btnRtaD.text = rtaD7;
                        break;
                    case 2:
                        btnRtaD.text = rtaA7;
                        btnRtaC.text = rtaB7;
                        btnRtaB.text = rtaC7;
                        btnRtaA.text = rtaD7;
                        break;
                    case 3:
                        btnRtaC.text = rtaA7;
                        btnRtaD.text = rtaB7;
                        btnRtaA.text = rtaC7;
                        btnRtaB.text = rtaD7;
                        break;
                    case 4:
                        btnRtaB.text = rtaA7;
                        btnRtaA.text = rtaB7;
                        btnRtaD.text = rtaC7;
                        btnRtaC.text = rtaD7;
                        break;
                }
                break;
        }

    }

    public void responderA()
    {
        if (btnRtaA.text.Equals(rtaCorrecta)) {
            ControlJugador.puntaje += 50;
            ControlJugador.numBalas += 3;
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    public void responderB()
    {
        if (btnRtaB.text.Equals(rtaCorrecta))
        {
            ControlJugador.puntaje += 50;
            ControlJugador.numBalas += 3;
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void responderC()
    {
        if (btnRtaC.text.Equals(rtaCorrecta))
        {
            ControlJugador.puntaje += 50;
            ControlJugador.numBalas += 3;
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;

        }
        else
        {
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void responderD()
    {
        if (btnRtaD.text.Equals(rtaCorrecta))
        {
            ControlJugador.puntaje += 50;
            ControlJugador.numBalas += 3;
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;

        }
        else
        {
            fondoPregunta.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
