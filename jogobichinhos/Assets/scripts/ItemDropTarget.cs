using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle;

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag?.GetComponent<ItemData>();
        if (item == null) return;

        Debug.Log("Item solto: " + item.tipo);

        controle.AumentarSaude(item.valor);

        // Chama o método certo no ControleSaude, dependendo do tipo
        if (item.tipo.ToLower() == "injecao")
        {
            controle.AplicarInjecao();
        }
        else if (item.tipo.ToLower() == "curativo")
        {
            controle.AplicarCurativo();
        }
        else if (item.tipo.ToLower() == "termometro")
        {
            controle.UsarTermometro();
        }

        Destroy(item.gameObject);
    }
}
