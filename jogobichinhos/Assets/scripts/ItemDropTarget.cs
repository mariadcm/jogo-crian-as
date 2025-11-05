using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle; // arraste o objeto que tem ControleSaude aqui

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag?.GetComponent<ItemData>();
        if (item == null) return;

        Debug.Log("ItemDropTarget: drop detectado item.tipo=" + item.tipo + " valor=" + item.valor);

        if (controle == null)
        {
            Debug.LogError("ItemDropTarget: controle (ControleSaude) NÃO está atribuído no Inspector!");
            Destroy(item.gameObject);
            return;
        }

        switch (item.tipo.ToLower())
        {
            case "injecao":
                controle.AplicarInjecao();
                break;

            case "curativo":
                controle.AplicarCurativo();
                break;

            case "termometro":
                controle.UsarTermometro();
                break;

            default:
                controle.AumentarSaude(item.valor);
                break;
        }

        Destroy(item.gameObject);
    }
}
