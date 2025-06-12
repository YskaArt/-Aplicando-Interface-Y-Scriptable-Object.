using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplayUI;

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void ShowGameplayUI()
    {
        pauseMenu.SetActive(false);
        gameplayUI.SetActive(true);
    }
}
