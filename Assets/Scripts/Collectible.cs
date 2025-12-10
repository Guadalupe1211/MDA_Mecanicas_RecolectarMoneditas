using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Configuración de Coleccionable")]
    public int experienciaOtorgada = 10;
    public int monedasOtorgadas = 1;
    public float velocidadRotacion = 50f;
    
    void Update()
    {
        // Hacer que la moneda rote para que se vea mejor
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador tocó la moneda
        if (other.CompareTag("Player"))
        {
            // Buscar el sistema de experiencia
            ExperienceSystem expSystem = other.GetComponent<ExperienceSystem>();
            if (expSystem != null)
            {
                expSystem.GanarExperiencia(experienciaOtorgada);
            }
            
            // Buscar el sistema de economía
            EconomySystem ecoSystem = other.GetComponent<EconomySystem>();
            if (ecoSystem != null)
            {
                ecoSystem.AgregarMonedas(monedasOtorgadas);
            }
            
            // Destruir la moneda
            Destroy(gameObject);
        }
    }
}