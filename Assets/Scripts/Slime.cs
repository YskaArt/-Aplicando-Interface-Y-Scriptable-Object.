using UnityEngine;

public class Slime : Enemigo
{
    public override void Accion()
    {
        Debug.Log($"{datos.Nombre} dice: {datos.Saludo}");
    }
}
