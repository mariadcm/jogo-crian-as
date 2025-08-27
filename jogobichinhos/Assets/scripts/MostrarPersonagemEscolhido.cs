using UnityEngine;

public class MostrarPersonagem : MonoBehaviour
{
    public GameObject Urso;
    public GameObject Hipopotamo;
    public GameObject Girafa;

    void Start()
    {
        Urso.SetActive(false);
        Hipopotamo.SetActive(false);
        Girafa.SetActive(false);

        Debug.Log("Personagem recebido na Consultorio: " + SelecionarPersonagem.personagemEscolhido);

        if (SelecionarPersonagem.personagemEscolhido == "Urso")
            Urso.SetActive(true);
        else if (SelecionarPersonagem.personagemEscolhido == "Hipopotamo")
            Hipopotamo.SetActive(true);
        else if (SelecionarPersonagem.personagemEscolhido == "Girafa")
            Girafa.SetActive(true);
    }
}