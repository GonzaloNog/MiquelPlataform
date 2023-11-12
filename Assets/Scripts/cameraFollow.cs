using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // El objeto que la cámara seguirá
    [SerializeField] private float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento
    [SerializeField] private float horizontalOffset = 2f; // Espacio adicional a los lados
    [SerializeField] private float verticalOffset = 2f; // Espacio adicional a los lados

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtiene el componente SpriteRenderer del personaje
            SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();

            // Verifica si el personaje está volteado en el eje X
            bool isFlipped = spriteRenderer != null && spriteRenderer.flipX;

            // Calcula la dirección del movimiento basándose en la orientación del personaje
            float moveDirection = isFlipped ? -1f : 1f;

            // Ajusta la posición de la cámara suavemente basándose en la dirección del movimiento
            Vector3 desiredPosition = new Vector3(target.position.x + moveDirection * horizontalOffset, target.position.y + verticalOffset, transform.position.z);
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
