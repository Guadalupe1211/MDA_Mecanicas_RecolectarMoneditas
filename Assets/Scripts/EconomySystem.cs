using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    [Header("Sistema de Economía")]
    public int monedasTotales = 0;
    
    // Método para agregar monedas
    public void AgregarMonedas(int cantidad)
    {
        monedasTotales += cantidad;
        Debug.Log("💰 ¡Recolectaste " + cantidad + " moneda(s)! Total: " + monedasTotales);
    }
    
    // Método para gastar monedas
    public bool GastarMonedas(int cantidad)
    {
        if (monedasTotales >= cantidad)
        {
            monedasTotales -= cantidad;
            Debug.Log("💸 Gastaste " + cantidad + " monedas. Te quedan: " + monedasTotales);
            return true;
        }
        else
        {
            Debug.Log("❌ No tienes suficientes monedas. Necesitas: " + cantidad + ", tienes: " + monedasTotales);
            return false;
        }
    }
}