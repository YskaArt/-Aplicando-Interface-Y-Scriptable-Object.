using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rangoDeInteraccion = 10f;
    public float rangoAtaque = 2f;
    public int dañoAtaque = 1;
    public float fuerzaSalto = 8f;

    public LayerMask capaEnemigos;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool enSuelo;
    public Transform sensorSuelo;
    public float radioSensor = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");

       
        transform.Translate(Vector3.right * movimiento * velocidad * Time.deltaTime);

        
        if (movimiento > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (movimiento < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        
        enSuelo = Physics2D.OverlapCircle(sensorSuelo.position, radioSensor, capaSuelo);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        // Interacción
        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractuarConEnemigoMasCercano();
        }

        // Ataque
        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarEnemigos();
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

    private void AtacarEnemigos()
    {
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, rangoAtaque, capaEnemigos);

        foreach (Collider2D col in enemigos)
        {
            ITakeDamage enemigo = col.GetComponent<ITakeDamage>();
            if (enemigo != null)
            {
                enemigo.TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);

        // Sensor de suelo
        if (sensorSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(sensorSuelo.position, radioSensor);
        }
    }
}
