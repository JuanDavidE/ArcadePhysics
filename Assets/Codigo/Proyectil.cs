using UnityEngine;
using System.Collections; 

//Creamos un tipo enumerado para definir la dirección
public enum Direccion { Horizontal, Vertical }

public class Proyectil : MonoBehaviour {

    //Variables públicas
    public Direccion DireccionArma = Direccion.Horizontal;
    public float Velocidad = 30.0F;

    //Variables privadas
    private Rigidbody2D thisRigidbody;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Establecemos su velocidad y su dirección
        if (DireccionArma == Direccion.Horizontal)
        {
            //Movemos el arma en horizontal
            thisRigidbody.transform.Translate(new Vector3(Velocidad, 0, 0) * Time.deltaTime);
        }
        else
        {
            //Movemos el arma en vertical
            thisRigidbody.transform.Translate(new Vector3(0, Velocidad, 0) * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombienmuertos")
        {
            //Si el ataque colisiona contra un objeto con el tag 'Enemigo', se decrementan las vidas de dicho enemigo
            other.gameObject.GetComponent<ControlZombie>().vidas--;

            //Destruimos el objeto cuando colisione contra un enemigo
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "zombienmuertosmujer")
        {
            //Si el ataque colisiona contra un objeto con el tag 'Enemigo', se decrementan las vidas de dicho enemigo
            other.gameObject.GetComponent<ControlZombieMujer>().vidas--;

            //Destruimos el objeto cuando colisione contra un enemigo
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Piso")
        {
            //Destruimos el objeto cuando colisione contra el piso
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "zombiengrandes")
        {
            //Si el ataque colisiona contra un objeto con el tag 'Enemigo', se decrementan las vidas de dicho enemigo
            other.gameObject.GetComponent<ControlZombiengrandes>().vidas--;

            //Destruimos el objeto cuando colisione contra un enemigo
            Destroy(gameObject);
        }
    }
}
