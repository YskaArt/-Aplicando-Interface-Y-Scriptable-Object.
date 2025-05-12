using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion
{
    [SerializeField] protected ScriptableEnemy datos;

    public virtual void Accion()
    {
        
    }

    private void Start()
    {
        Debug.Log($"Apareció un {datos.Nombre} con {datos.Vida} de vida.");
        
    }
}
