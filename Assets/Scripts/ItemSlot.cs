using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Header("Identificador de la Forma")]
    public string requiredID; // Debe coincidir con el itemID correspondiente (ej: "Colmillo")

    [HideInInspector] public bool isSolved = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            DraggableItem draggable = droppedObject.GetComponent<DraggableItem>();

            // Verifica si el objeto es correcto y si la ranura no está ocupada
            if (draggable != null && draggable.itemID == requiredID && !isSolved)
            {
                // Asigna la pieza a este espacio
                draggable.parentAfterDrag = transform;

                // Centra la pieza dentro de la forma objetivo
                draggable.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

                // Desactiva la posibilidad de seguir arrastrándola
                draggable.enabled = false;

                isSolved = true;

                // Notifica al manager que se ha colocado una pieza correcta
                PuzzleManager.Instance.CheckPuzzleProgress();
            }
        }
    }
}