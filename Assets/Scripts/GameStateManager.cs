using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onGameStart;
    [SerializeField] private UnityEvent onGamePause;

    private bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
            onGamePause?.Invoke();
        else
            onGameStart?.Invoke();
    }

    public bool IsPaused() => isPaused;
}
