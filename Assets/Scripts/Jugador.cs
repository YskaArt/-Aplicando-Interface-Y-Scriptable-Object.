
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rangoDeInteraccion = 10f;

    private void Update()
    {
       
        float movimiento = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movimiento * velocidad * Time.deltaTime);

        if (movimiento > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (movimiento < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        // Interacción con enemigo más cercano
        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractuarConEnemigoMasCercano();
        }
    }

    private void InteractuarConEnemigoMasCercano()
    {
        IPresentacion enemigoMasCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (Enemigo enemigo in FindObjectsByType<Enemigo>(FindObjectsSortMode.None))
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);

            if (distancia < distanciaMinima && distancia <= rangoDeInteraccion)
            {
                distanciaMinima = distancia;
                enemigoMasCercano = enemigo;
            }
        }

        if (enemigoMasCercano != null)
        {
            enemigoMasCercano.Accion();
        }
        else
        {
            Debug.Log("No hay enemigos cercanos.");
        }
    }
}
