using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropTarget : MonoBehaviour, IDropHandler
{
    public ControleSaude controle; 

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag?.GetComponent<ItemData>();
        if (item == null)
        {
            Debug.Log("[ItemDropTarget] OnDrop: item == null");
            return;
        }

        string tipo = (item.tipo ?? "").ToLower().Trim();
        Debug.Log("[ItemDropTarget] Item solto: tipo=" + tipo + " valor=" + item.valor);

        if (controle == null)
        {
            Debug.LogError("[ItemDropTarget] controle NÃO está atribuído no Inspector!");
            Destroy(item.gameObject);
            return;
        }

        // 1) Aumenta a saúde *uma vez* com o valor do item
        controle.AumentarSaude(item.valor);

        // 2) Chama o método para tratar a etapa (mostrar próximo balão / finalizar)
        if (tipo == "injecao")
            controle.AplicarInjecao();      // mostra balão do curativo
        else if (tipo == "curativo")
            controle.AplicarCurativo();     // mostra balão do termômetro
        else if (tipo == "termometro")
            controle.AplicarTermometro();   // finaliza se saúde >= 100
        else
            Debug.LogWarning("[ItemDropTarget] tipo não reconhecido: " + item.tipo);

        // 3) remove o item usado
        Destroy(item.gameObject);
    }
}
