using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int itemCount = 0;

    public void AddItem()
    {
        itemCount++;
        Debug.Log("Item recolectado. Total: " + itemCount);
    }

    public int GetItemCount() => itemCount;
}
