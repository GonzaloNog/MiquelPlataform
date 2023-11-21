using UnityEngine;

public class CoinBox : MonoBehaviour
{
    public GameObject coinPrefab; // Objeto de la moneda u otro power-up
    public float upwardForce = 5f; // Fuerza hacia arriba al ser golpeado
    public float moveSpeed = 10f; // Velocidad de movimiento de la caja
    public float coinSpeed = 15f; // Velocidad de la moneda al salir
    public Color grayColor = new Color(0.5f, 0.5f, 0.5f, 1f); // Color en escala de grises

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;
    private PointsManager pointsManager;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        if (pointsManager == null)
        {
            Debug.LogError("No se encontró una instancia de PointsManager en la escena.");
        }
    }
   

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SuperGirl") && !isActivated)
        {
            isActivated = true;
            GenerateCoin();

            // Cambia la caja a escala de grises
            SetGrayColor();

            // Mueve la caja hacia arriba y luego vuelve a su posición
            StartCoroutine(MoveBox());
            pointsManager.IncrementarPuntuacion(1);
        }
    }

    void GenerateCoin()
    {
        // Genera el objeto de la moneda (o cualquier otro power-up)
        GameObject coinObject = Instantiate(coinPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        // Verifica si el objeto de la moneda tiene un componente Rigidbody2D
        Rigidbody2D coinRb = coinObject.GetComponent<Rigidbody2D>();
        if (coinRb != null)
        {
            // Ajusta la velocidad de la moneda si tiene un componente Rigidbody2D
            coinRb.velocity = new Vector2(0, coinSpeed);
        }
        else
        {
            Debug.LogError("El objeto de la moneda no tiene un componente Rigidbody2D adjunto.");
        }

        // Comienza la rutina para desvanecer la moneda después de un segundo
        StartCoroutine(FadeCoin(coinObject));
    }

    System.Collections.IEnumerator FadeCoin(GameObject coinObject)
    {
        // Espera un segundo antes de comenzar a desvanecer la moneda
        yield return new WaitForSeconds(1f);

        // Desvanecer la moneda
        SpriteRenderer coinRenderer = coinObject.GetComponent<SpriteRenderer>();
        if (coinRenderer != null)
        {
            float fadeTime = 1f; // Tiempo total de desvanecimiento
            float currentTime = 0f;

            while (currentTime < fadeTime)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeTime);
                coinRenderer.color = new Color(1f, 1f, 1f, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }

            // Asegúrate de que la moneda esté completamente desvanecida
            coinRenderer.color = new Color(1f, 1f, 1f, 0f);

            // Destruye la moneda después de desvanecerse
            Destroy(coinObject);
        }
        else
        {
            Debug.LogError("El objeto de la moneda no tiene un componente SpriteRenderer adjunto.");
        }
    }


    void SetGrayColor()
    {
        // Cambia el color del sprite a escala de grises
        spriteRenderer.color = grayColor;
    }

    System.Collections.IEnumerator MoveBox()
    {
        float originalY = transform.position.y;
        float targetY = originalY + upwardForce;

        // Mueve la caja hacia arriba
        while (transform.position.y < targetY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            yield return null;
        }

        // Mueve la caja de nuevo a su posición original
        while (transform.position.y > originalY)
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
