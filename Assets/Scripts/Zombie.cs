using UnityEngine;

public class Zombie : Enemigo
{
    public override void Accion()
    {
        Debug.Log($"{datos.Nombre} dice: {datos.Saludo}");
    }
}
