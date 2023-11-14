using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour
{
    public float amplitude = 2f; // Amplitud de la curva
    public float frequency = 1f; // Frecuencia de la curva
    public float speed = 2f; // Velocidad de movimiento vertical
    public float initialOffset = 0f; // Desplazamiento inicial en el eje Y
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float verticalOffset = amplitude * Mathf.Sin(frequency * elapsedTime) + initialOffset;
        transform.position = new Vector3(transform.position.x, verticalOffset, transform.position.z);

        // Agrega movimiento vertical a lo largo del tiempo
        float verticalMovement = Mathf.Sin(Time.time * speed);
        transform.Translate(Vector3.up * verticalMovement * Time.deltaTime);
    }
}
