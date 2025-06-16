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
    public void NextLevel()
    {

        int current = int.Parse(currentLevel.Split(' ')[1]);
        current++;
        ChangeLevel(" " + current);
    }

    public string GetCurrentLevel() => currentLevel;
}
