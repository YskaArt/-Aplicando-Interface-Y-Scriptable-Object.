using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion, ITakeDamage
{
    [SerializeField] protected ScriptableEnemy datos;

    private int vidaActual;

    private void Start()
    {
        vidaActual = datos.Vida;
        Debug.Log($"Apareció un {datos.Nombre} con {vidaActual} de vida.");
       
    }

    public virtual void Accion()
    {     
        //Esto se reescribe dentro de cada Enemigo
    }

    public void TomarDaño(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{datos.Nombre} recibió {cantidad} de daño. Vida restante: {vidaActual}");

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
