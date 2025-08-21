using UnityEngine;
using UnityEngine.SceneManagement; // Para mudar de cena

public class SelecionarPersonagem : MonoBehaviour
{
    // Vamos guardar o nome do personagem que o jogador escolheu
    public static string personagemEscolhido;

    // Função que será chamada quando clicar no botão
    public void EscolherPersonagem(string nomePersonagem)
    {
        personagemEscolhido = nomePersonagem;
        // Agora vamos para a cena do jogo (troque pelo nome da sua cena)
        SceneManager.LoadScene("Consutorio");

    }
}
