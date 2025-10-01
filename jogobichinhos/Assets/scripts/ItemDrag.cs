using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 inicio;

    public void OnBeginDrag(PointerEventData eventData)
    {
        inicio = transform.position; // guarda a posição inicial
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // segue o mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // se não soltar em cima do bichinho, volta pro lugar
        transform.position = inicio;
    }
}
