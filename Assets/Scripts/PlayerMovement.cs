using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 5f;
    
    private Rigidbody rb;
    private bool estaEnSuelo = true;
    
    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // Obtener input del jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A/D o Flechas
        float movimientoVertical = Input.GetAxis("Vertical");     // W/S o Flechas
        
        // Crear vector de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        
        // Aplicar movimiento
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);
        
        // Salto con Espacio
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnSuelo = false;
        }
    }
    
    // Detectar cuando toca el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            estaEnSuelo = true;
        }
    }
}