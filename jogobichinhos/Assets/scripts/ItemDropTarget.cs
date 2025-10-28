using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle;

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag?.GetComponent<ItemData>();
        if (item == null) return;

        controle.AumentarSaude(item.valor);
        Destroy(item.gameObject);
    }
}

