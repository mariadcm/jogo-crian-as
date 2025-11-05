using UnityEngine;
using UnityEngine.UI;

public class BalaoDeFala : MonoBehaviour
{
    [Header("Configurações do Balão")]
    public GameObject balaoObjeto; // o GameObject do balão (com a imagem e texto)
    public Text textoMensagem;     // o texto dentro do balão
    public Transform personagem;   // o personagem sobre o qual o balão aparece
    public Vector3 offset = new Vector3(0, 2f, 0); // altura acima da cabeça

    void Update()
    {
        if (balaoObjeto.activeSelf && personagem != null)
        {
            // Faz o balão seguir o personagem na tela
            Vector3 posTela = Camera.main.WorldToScreenPoint(personagem.position + offset);
            balaoObjeto.transform.position = posTela;
        }
    }

    public void MostrarMensagem(string mensagem)
    {
        textoMensagem.text = mensagem;
        balaoObjeto.SetActive(true);
    }

    public void EsconderMensagem()
    {
        balaoObjeto.SetActive(false);
    }
}

