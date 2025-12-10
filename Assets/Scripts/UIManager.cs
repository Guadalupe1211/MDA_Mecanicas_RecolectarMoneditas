using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    public Text textoMonedas;
    public Text textoNivel;
    public Text textoXP;
    
    [Header("Referencias de Sistemas")]
    public EconomySystem economySystem;
    public ExperienceSystem experienceSystem;
    
    void Update()
    {
        // Actualizar texto de monedas
        if (economySystem != null && textoMonedas != null)
        {
            textoMonedas.text = "💰 Monedas: " + economySystem.monedasTotales;
        }
        
        // Actualizar texto de nivel
        if (experienceSystem != null && textoNivel != null)
        {
            textoNivel.text = "⭐ Nivel: " + experienceSystem.nivel;
        }
        
        // Actualizar texto de XP
        if (experienceSystem != null && textoXP != null)
        {
            textoXP.text = "✨ XP: " + experienceSystem.experienciaActual + "/" + experienceSystem.experienciaNecesaria;
        }
    }
}