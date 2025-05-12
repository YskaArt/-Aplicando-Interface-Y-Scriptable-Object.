using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion, ITakeDamage
{
    [SerializeField] protected ScriptableEnemy datos;

    private int vidaActual;

    private void Start()
    {
        vidaActual = datos.Vida;
        Debug.Log($"Apareci� un {datos.Nombre} con {vidaActual} de vida.");
       
    }

    public virtual void Accion()
    {     
        //Esto se reescribe dentro de cada Enemigo
    }

    public void TomarDa�o(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{datos.Nombre} recibi� {cantidad} de da�o. Vida restante: {vidaActual}");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        Debug.Log($"{datos.Nombre} ha muerto.");
        Destroy(gameObject);
    }
}
