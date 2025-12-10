using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    [Header("Sistema de Experiencia")]
    public int experienciaActual = 0;
    public int experienciaNecesaria = 100;
    public int nivel = 1;
    
    [Header("Bonus por Nivel")]
    public float bonusVelocidad = 0.5f;
    
    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    // Método para ganar experiencia
    public void GanarExperiencia(int cantidad)
    {
        experienciaActual += cantidad;
        Debug.Log("¡Ganaste " + cantidad + " XP! Total: " + experienciaActual + "/" + experienciaNecesaria);
        
        // Verificar si sube de nivel
        if (experienciaActual >= experienciaNecesaria)
        {
            SubirNivel();
        }
    }
    
    void SubirNivel()
    {
        nivel++;
        experienciaActual -= experienciaNecesaria;
        experienciaNecesaria = Mathf.RoundToInt(experienciaNecesaria * 1.5f); // Aumenta 50% cada nivel
        
        // Aumentar velocidad del jugador
        if (playerMovement != null)
        {
            playerMovement.velocidadMovimiento += bonusVelocidad;
        }
        
        Debug.Log("🎉 ¡SUBISTE AL NIVEL " + nivel + "! Velocidad aumentada a: " + playerMovement.velocidadMovimiento);
    }
    
    // Método para obtener el progreso (0 a 1)
    public float ObtenerProgreso()
    {
        return (float)experienciaActual / experienciaNecesaria;
    }
}