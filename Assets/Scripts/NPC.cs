using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteracted;

    public void Interact()
    {
        onInteracted?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
