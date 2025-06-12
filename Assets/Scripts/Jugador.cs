using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rangoDeInteraccion = 10f;
    public float rangoAtaque = 2f;
    public int dañoAtaque = 1;
    public float fuerzaSalto = 8f;

   
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

        
    }

    
  
}
