using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecionarPersonagem : MonoBehaviour
{
    public static string personagemEscolhido;

    public void EscolherPersonagem(string nome)
    {
        personagemEscolhido = nome;
        Debug.Log("Personagem selecionado: " + personagemEscolhido);
        SceneManager.LoadScene("Consultorio"); // Troca para a cena desejada
    }
}