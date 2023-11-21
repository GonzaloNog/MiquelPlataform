using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int puntuacion = 0;
    public Text puntuacionText;

    void Start()
    {
        // Asegúrate de que el objeto Text esté asignado desde el Inspector
        if (puntuacionText != null)
        {
            ActualizarPuntuacionText();
        }
    }

    void ActualizarPuntuacionText()
    {
        puntuacionText.text = "Points: " + puntuacion.ToString();
    }

    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion += puntos;
        ActualizarPuntuacionText();
    }
}
