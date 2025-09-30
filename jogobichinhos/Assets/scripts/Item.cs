using UnityEngine;

public class Item : MonoBehaviour
{
    public ControleSaude controle;   // arraste o GameController aqui
    public float valor = 30f;        // quanto aumenta a saúde
    public bool ehInjecao = false;   // marque true para a seringa
    public bool precisaInjecao = false; // marque true para o band-aid

    bool usado = false;

    public void UsarItem()
    {
        if (usado) return;
        if (controle == null)
        {
            Debug.LogWarning("Item: controle não foi arrastado no Inspector!");
            return;
        }

        // Band-aid só funciona se a injeção já tiver sido dada
        if (precisaInjecao && !controle.injecaoDada)
        {
            Debug.Log("Precisa usar a injeção antes!");
            return;
        }

        usado = true;

        // Marca que a injeção foi dada
        if (ehInjecao)
        {
            controle.injecaoDada = true;
            Debug.Log("Injeção dada!");
        }

        // Aumenta saúde
        controle.AumentarSaude(valor);

        // Some da cena
        gameObject.SetActive(false);
    }
}
