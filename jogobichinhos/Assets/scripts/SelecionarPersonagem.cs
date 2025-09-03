using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelecionarPersonagem : MonoBehaviour
{
    public static string personagemEscolhido;
    public Image telaPreta;      // arraste a Image aqui no Inspector
    public float tempoFade = 0.5f;
    bool emTransicao = false;

    public void EscolherPersonagem(string nome)
    {
        if (emTransicao) return; // evita clique duplo
        personagemEscolhido = nome;
        Debug.Log("Personagem selecionado: " + personagemEscolhido);

        // Se a telaPreta não foi ligada no Inspector, vai direto (fallback)
        if (telaPreta == null)
        {
            SceneManager.LoadScene("Consultorio");
            return;
        }

        StartCoroutine(FazerFade());
    }

    System.Collections.IEnumerator FazerFade()
    {
        emTransicao = true;

        // Garante que a imagem está visível e começando transparente
        var cor = telaPreta.color;
        cor.a = 0f;
        telaPreta.color = cor;

        // Não deixe a TelaPreta bloquear cliques antes do fade
        telaPreta.raycastTarget = false;

        float t = 0f;
        while (t < tempoFade)
        {
            t += Time.deltaTime;
            cor.a = Mathf.Lerp(0f, 1f, t / tempoFade); // 0 -> 1
            telaPreta.color = cor;
            yield return null;
        }

        SceneManager.LoadScene("Consultorio");
    }
}