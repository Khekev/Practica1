using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Identificador")]
    public string itemID; //  "Colmillo", "Ooze", "Huevo"

    [HideInInspector] public Transform parentAfterDrag;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        //  CanvasGroup para gestionar Raycasts durante el arrastre
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;

        // Mueve la pieza al frente del Canvas para que no quede detrás de otras imágenes
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        // Desactiva los raycasts en la pieza para detectar el drop en el socket inferior
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Actualiza la posición de la pieza siguiendo el cursor o dedo
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restaura la jerarquía y activa de nuevo los raycasts
        transform.SetParent(parentAfterDrag);
        canvasGroup.blocksRaycasts = true;
    }
}
