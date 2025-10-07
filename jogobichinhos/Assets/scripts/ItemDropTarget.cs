using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerDrag;
        if (obj == null) return;

        ItemData item = obj.GetComponent<ItemData>();
        if (item == null) return;

        // Regras do jogo
        if (item.tipo == "BandAid" && controle.injecaoDada == false)
        {
            Debug.Log("Precisa dar a injeção antes!");
            return;
        }

        if (item.tipo == "Injecao")
            controle.injecaoDada = true;

        // Aumenta a saúde
        controle.AumentarSaude(item.valor);

        // Some o item
        obj.SetActive(false);
    }
}
