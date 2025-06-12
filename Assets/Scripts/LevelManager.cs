using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StringEvent : UnityEvent<string>
{
}

public class LevelManager : MonoBehaviour
{
    public StringEvent onLevelChanged;

    private string currentLevel = "Nivel 1";

    public void ChangeLevel(string newLevel)
    {
        currentLevel = newLevel;
        onLevelChanged?.Invoke(currentLevel);
    }

    public string GetCurrentLevel() => currentLevel;
}
