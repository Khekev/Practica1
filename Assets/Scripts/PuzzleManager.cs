using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    [Header("Ranuras del Rompecabezas")]
    public ItemSlot[] slots = new ItemSlot[3];

    [Header("Eventos al Completar")]
    public UnityEvent onPuzzleCompleted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckPuzzleProgress()
    {
        // Revisa si las 3 ranuras han sido resueltas
        foreach (ItemSlot slot in slots)
        {
            if (!slot.isSolved)
            {
                return; // Todavía faltan piezas por colocar
            }
        }

        // Si todas están completadas:
        Debug.Log("¡Kaiju completado! Avanza hacia el ultimo QR!!!.");
        CompletarPuzzle();
    }

    private void CompletarPuzzle()
    {
        // Ejecuta eventos configurados desde la interfaz o por código (ej. abrir puerta, cambiar de escena)
        onPuzzleCompleted?.Invoke();
    }
}
