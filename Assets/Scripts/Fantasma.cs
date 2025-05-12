using UnityEngine;

public class Fantasma : Enemigo
{
    public override void Accion()
    {
        Debug.Log($"{datos.Nombre} dice: {datos.Saludo}");
    }
}
