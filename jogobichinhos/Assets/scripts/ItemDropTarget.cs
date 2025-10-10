using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle; // arraste o GameController do bichinho aqui

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragged = eventData.pointerDrag;
        if (dragged == null) return;

        ItemData data = dragged.GetComponent<ItemData>();
        if (data == null) return;

        // regras
        if (data.tipo == "BandAid" && controle.injecaoDada == false)
        {
            Debug.Log("Use a injeção primeiro!");
            return;
        }
        if (data.tipo == "Injecao") controle.injecaoDada = true;

        controle.AumentarSaude(data.valor);
        dragged.SetActive(false);
        Debug.Log("Usou " + data.tipo + " -> +" + data.valor);
    }
}

