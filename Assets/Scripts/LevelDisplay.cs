using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TMP_Text levelText;

    private void Awake()
    {
        levelText.text = $"Nivel Actual: 1";
    }
    private void OnEnable()
    {
        levelManager?.onLevelChanged.AddListener(UpdateLevelDisplay);
    }

    private void OnDisable()
    {
        levelManager?.onLevelChanged.RemoveListener(UpdateLevelDisplay);
    }

    public void UpdateLevelDisplay(string newLevel)
    {
        if (levelText != null)
            levelText.text = $"Nivel Actual: {newLevel}";
    }
}
