using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        // Desactivar el panel al inicio
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        // Activar el panel cuando se llama al método
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
