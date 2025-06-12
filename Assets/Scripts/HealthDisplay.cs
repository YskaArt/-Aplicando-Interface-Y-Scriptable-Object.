using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text healthText;

    private void OnEnable()
    {
        playerHealth?.onHealthChanged.AddListener(UpdateHealthText);
    }

    private void OnDisable()
    {
        playerHealth?.onHealthChanged.RemoveListener(UpdateHealthText);
    }

    public void UpdateHealthText(int newHealth)
    {
        if (healthText != null)
            healthText.text = $"Salud: {newHealth}";
    }
}
